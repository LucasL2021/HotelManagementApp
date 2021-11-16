using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CustomerCardResponseModel
    {
        public int Id { get; set; }
        public string Cname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
