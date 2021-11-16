using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CustomerBookingResponseModel
    {
        public int RoomNO { get; set; }
        public int RTCode { get; set; }
        public RoomResponseModel RoomType2 { get; set; }
        public IEnumerable<ServiceResponseModel> Services2 { get; set; }
    }
}
