using casa_del_mar.Models;
using casa_del_mar.Types.Api.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using casa_del_mar.Services.Reservation;

namespace casa_del_mar.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private ApplicationContext db;

        public RoomController(ApplicationContext context)
        {
            db = context;
        }

        [Route("list")]
        [HttpGet]
        public async Task<ActionResult<List<Room>>> Get()
        {
            return Ok(await db.Rooms.ToListAsync());
        }

        
        [Route("aviable-list")]
        [HttpPut]
        public async Task<ActionResult<List<Room>>> Get(IRoomsDatesParams datesParams)
        {
            List<Room> rooms = await db.Rooms.ToListAsync();
            List<Room> aviableRooms = new List<Room>();

            try
            {
                DateTime start = TimeZoneInfo.ConvertTimeToUtc(DateTime.ParseExact(datesParams.startTime, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture));
                DateTime end = TimeZoneInfo.ConvertTimeToUtc(DateTime.ParseExact(datesParams.endTime, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture));

                foreach (var room in rooms)
                {
                    List<ReservatedDates> roomReservations = db.ReservatedDates.Where(x => x.roomID == room.ID).ToList();

                    if (CheckReservatedDates.isDateAvalible(start, end, roomReservations)) aviableRooms.Add(room);
                }
            }
            catch
            {
                return BadRequest("Неверный формат даты");
            }

            return aviableRooms;
        }
        

        [Route("add")]
        [HttpPost]
        public async Task<ActionResult<Room>> Create(IRoomAddParams room)
        {
            if (room == null) return BadRequest("Неверные данные");

            Room newRoom = new Room();
            newRoom.Name = room.name;
            newRoom.Description = room.description;
            newRoom.PhotoURL = room.photoURL;
            newRoom.Price = room.price;

            await db.Rooms.AddAsync(newRoom);
            await db.SaveChangesAsync();
            return Ok(newRoom);
        }

        [Route("update")]
        [HttpPut]
        public async Task<ActionResult<Room>> Update(Room room)
        {
            if (room == null) return BadRequest("Неверные данные");

            if (!db.Rooms.Any(x => x.ID == room.ID)) return NotFound("Комната не найдена");

            db.Rooms.Update(room);
            await db.SaveChangesAsync();
            return Ok(room);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<ActionResult<Room>> Delete(int id)
        {
            Room? room = await db.Rooms.FirstOrDefaultAsync(x => x.ID == id);
            if (room == null) return NotFound("Комната не найдена");

            db.Rooms.Remove(room);
            await db.SaveChangesAsync();
            return Ok(room);
        }
    }
}
