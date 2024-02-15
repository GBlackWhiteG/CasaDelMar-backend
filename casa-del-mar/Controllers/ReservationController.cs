using casa_del_mar.Models;
using casa_del_mar.Types.Api.Reservation;
using casa_del_mar.Types.Api.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace casa_del_mar.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private ApplicationContext db;

        public ReservationController(ApplicationContext context)
        {
            db = context;
        }

        [Route("get")]
        [HttpGet]
        public async Task<ActionResult<ReservatedDates>> Get(int id)
        {
            ReservatedDates? order = await db.ReservatedDates.FirstOrDefaultAsync(x => x.reservationDatesID == id);
            if (order == null) return BadRequest("Заказ не найден");

            return Ok(order);
        }

        [Route("list")]
        [HttpGet]
        public async Task<ActionResult<List<ReservatedDates>>> GetAll()
        {
            return Ok(await db.ReservatedDates.ToListAsync());
        }

        [Route("add")]
        [HttpPost]
        public async Task<ActionResult<ReservatedDates>> Get(IReservationDatesParams orderParams)
        {
            Room? room = db.Rooms.FirstOrDefault(x => x.ID == orderParams.roomID);

            if (room == null) return BadRequest("Комната не найдена");
            ReservatedDates order = new ReservatedDates();
            try
            {
                order.start = TimeZoneInfo.ConvertTimeToUtc(DateTime.ParseExact(orderParams.startTime, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture));
                order.end = TimeZoneInfo.ConvertTimeToUtc(DateTime.ParseExact(orderParams.endTime, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture));
            }
            catch
            {
                return BadRequest($"Неверный формат даты: {orderParams.startTime}");
            }

            order.fullName = orderParams.fullName;
            order.email = orderParams.email;
            order.phoneNumber = orderParams.phoneNumber;
            order.adultsCount = orderParams.adultsCount;
            order.childrenCount = orderParams.childrenCount;
            order.roomID = orderParams.roomID;

            db.ReservatedDates.Update(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }

        [Route("update")]
        [HttpPut]
        public async Task<ActionResult> Update(ReservatedDates order)
        {
            if (order == null) return BadRequest("Неверные данные");

            if (!db.ReservatedDates.Any(x => x.reservationDatesID == order.reservationDatesID)) return BadRequest("Заказ не найден");

            db.ReservatedDates.Update(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            ReservatedDates? reservation = await db.ReservatedDates.FirstOrDefaultAsync(x => x.reservationDatesID == id);
            if (reservation == null) return BadRequest("Бронирование не найдено");

            db.ReservatedDates.Remove(reservation);
            await db.SaveChangesAsync();
            return Ok(reservation);
        }
    }
}