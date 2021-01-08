using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemParcelType
    {
        public int Id { get; set; }
        public string ParceType { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string UserId { get; set; }
    }
}
