namespace casa_del_mar.Types.Api.Reservation
{
    public class IReservationDatesParams
    {
        public int roomID { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public int? adultsCount { get; set; }
        public int? childrenCount { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}
