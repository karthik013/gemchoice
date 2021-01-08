using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemTreatment
    {
        public int Id { get; set; }
        public string Treatment { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string Userid { get; set; }
    }
}
