using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemProducts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Packid { get; set; }
        public string PacketNo { get; set; }
        public string Boxid { get; set; }
        public string GemType { get; set; }
        public string GemName { get; set; }
        public string GemShape { get; set; }
        public string GemOrigin { get; set; }
        public string GemCut { get; set; }
        public string GemSizeRange { get; set; }
        public string GemTreatment { get; set; }
        public string GemColor { get; set; }
        public string GemColorShade { get; set; }
        public string GemClarity { get; set; }
        public decimal? GemCarat { get; set; }
        public int? GemPieces { get; set; }
        public string GemPrice { get; set; }
        public decimal? DiscountAmt { get; set; }
        public string PicProfile { get; set; }
        public string Picfront { get; set; }
        public string PicSide { get; set; }
        public string PicTop { get; set; }
        public string Video { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? UDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsFeatured { get; set; }
        public string DiscountCode { get; set; }
        public int? Orderid { get; set; }
        public bool? IsArchived { get; set; }
    }
}
