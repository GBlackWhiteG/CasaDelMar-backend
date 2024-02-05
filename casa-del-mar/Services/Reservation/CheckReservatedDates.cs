using casa_del_mar.Models;

namespace casa_del_mar.Services.Reservation
{
    public class CheckReservatedDates
    {
        public static bool isDateAvalible(DateTime start, DateTime end, List<ReservatedDates> reservations)
        {
            foreach (var reservation in reservations)
            {
                if (!(start > reservation.end || end < reservation.start)) return false;
            }

            return true;
        }
    }
}
