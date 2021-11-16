using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public int RoomNO { get; set; }
        [MaxLength(50)]
        public string? SDESC { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? ServiceDate { get; set; }

        public Room Room { get; set; }
    }
}
