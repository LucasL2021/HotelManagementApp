﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string? RTDESC { get; set; }
        public decimal? Rent { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
