using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemColorShade
    {
        public int Id { get; set; }
        public string Shade { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string Userid { get; set; }
        public int GemColor { get; set; }

        public virtual GemColor GemColorNavigation { get; set; }
    }
}
