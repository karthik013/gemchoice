using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemShape
    {
        public GemShape()
        {
            GemSizeRange = new HashSet<GemSizeRange>();
        }

        public int Id { get; set; }
        public string Shape { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string Userid { get; set; }

        public virtual ICollection<GemSizeRange> GemSizeRange { get; set; }
    }
}
