using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemCert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public string Userid { get; set; }
        public string ProductId { get; set; }

        public virtual GemMasterProducts Product { get; set; }
    }
}
