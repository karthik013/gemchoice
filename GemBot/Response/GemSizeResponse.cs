using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemBot.Response
{
    public class GemSizeResponse
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string Userid { get; set; }
        public string GemShape { get; set; }
    }
}
