using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemColor
    {
        public GemColor()
        {
            GemColorShade = new HashSet<GemColorShade>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string Userid { get; set; }

        public virtual ICollection<GemColorShade> GemColorShade { get; set; }
    }
}
