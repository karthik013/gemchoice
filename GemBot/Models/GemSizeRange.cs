using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemSizeRange
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string Userid { get; set; }
        public int? GemShape { get; set; }

        public virtual GemShape GemShapeNavigation { get; set; }
    }
}
