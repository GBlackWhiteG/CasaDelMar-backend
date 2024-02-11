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

        [Route("list")]
        [HttpGet]
        public async Task<ActionResult<List<ReservatedDates>>> GetAll()
        {
            return Ok(await db.ReservatedDates.ToListAsync());
        }

        [Route("add")]
        [HttpPost]
        public async Task<ActionResult<ReservatedDates>> Get(IReservationDatesParams datesParams)
        {
            Room? room = db.Rooms.FirstOrDefault(x => x.ID == datesParams.roomID);

            if (room == null) return BadRequest("Комната не найдена");
            ReservatedDates dates = new ReservatedDates();
            try
            {
                dates.start = TimeZoneInfo.ConvertTimeToUtc(DateTime.ParseExact(datesParams.startTime, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture));
                dates.end = TimeZoneInfo.ConvertTimeToUtc(DateTime.ParseExact(datesParams.endTime, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture));
                dates.roomID = datesParams.roomID;
            }
            catch
            {
                return BadRequest($"Неверный формат даты: {datesParams.startTime}");
            }

            db.ReservatedDates.Update(dates);
            await db.SaveChangesAsync();
            return Ok(dates);
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