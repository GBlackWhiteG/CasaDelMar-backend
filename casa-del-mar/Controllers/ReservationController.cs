using casa_del_mar.Models;
using casa_del_mar.Types.Api.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

            if (!db.Rooms.Any())
            {
                db.Rooms.Add(new Room {
                    Name = "Делюкс номер",
                    Description = "Резиновые утки для серфинга и ночные истории с мраморными ванными комнатами и кроватями с балдахином - даже роскошь иногда требует перерыва для игр.",
                    PhotoURL = "../../media/rooms/delux.jpg",
                    Price = 55767,
                });

                db.SaveChanges();
            }
        }

        [Route("list")]
        [HttpGet]
        public async Task<ActionResult<List<Room>>> Get()
        {
            return await db.Rooms.ToListAsync();

            //return dates;
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
