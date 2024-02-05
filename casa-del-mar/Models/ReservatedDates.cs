using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace casa_del_mar.Models
{
    public class ReservatedDates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reservationDatesID { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public int? roomID { get; set; }
    }
}
