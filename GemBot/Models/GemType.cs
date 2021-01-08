using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string Userid { get; set; }
    }
}
