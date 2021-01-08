using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemBot.Response
{
    public class GemColorShadeResponse
    {
        public int Id { get; set; }
        public string Shade { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string Userid { get; set; }
        public string GemColor { get; set; }
    }
}
