using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemMasterProducts
    {
        public GemMasterProducts()
        {
            GemCert = new HashSet<GemCert>();
        }

        public string Name { get; set; }
        public string GeneratedRefId { get; set; }
        public string GemType { get; set; }
        public string ParcelType { get; set; }
        public string RefNo { get; set; }
        public string CaretWeight { get; set; }
        public string FinishType { get; set; }
        public string Shape { get; set; }
        public string Treatment { get; set; }
        public string Size { get; set; }
        public string SizeRange { get; set; }
        public string Origin { get; set; }
        public string Cut { get; set; }
        public string Color { get; set; }
        public string Shade { get; set; }
        public string Clarity { get; set; }
        public string PricePerPiece { get; set; }
        public string PricePerCarat { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public bool IsActive { get; set; }
        public string GemProfile { get; set; }
        public string GemFrontView { get; set; }
        public string GemSideView { get; set; }
        public string GemTopView { get; set; }
        public string GemVideo { get; set; }
        public DateTime? CDate { get; set; }
        public bool? Isfeatured { get; set; }
        public DateTime? UDate { get; set; }
        public string Discount { get; set; }
        public string DiscountCode { get; set; }
        public string IsArchieved { get; set; }
        public string GemCertificate { get; set; }
        public string GemColorVariation { get; set; }

        public virtual ICollection<GemCert> GemCert { get; set; }
    }
}
