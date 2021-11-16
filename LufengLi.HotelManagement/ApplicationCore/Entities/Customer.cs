using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public int RoomNo { get; set; }
        [MaxLength(20)]
        public string? Cname { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(40)]
        public string? Email { get; set; }
        public DateTime? CheckIn { get; set; }
        public int? TotalPersons { get; set; }
        public int? BookingDays { get; set; }
        public decimal? Advance { get; set; }

        public Room Room { get; set; }
    }
}
