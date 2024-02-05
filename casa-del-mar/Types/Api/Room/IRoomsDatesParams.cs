using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace casa_del_mar.Types.Api.Room
{
    public class IRoomsDatesParams
    {
        public string startTime {  get; set; }
        public string endTime { get; set; }
    }
}
