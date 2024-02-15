using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace casa_del_mar.Models
{
    public class ReservatedDates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reservationDatesID { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public int? adultsCount { get; set; }
        public int? childrenCount { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public int? roomID { get; set; }
    }
}
