using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class ServiceResponseModel
    {
        public int Id { get; set; }
        public int RoomNO { get; set; }
        public string? SDESC { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? ServiceDate { get; set; }

    }
}
