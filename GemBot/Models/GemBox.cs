using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemBox
    {
        public int Id { get; set; }
        public string RefNo { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Drawer { get; set; }
        public string Location { get; set; }
    }
}
