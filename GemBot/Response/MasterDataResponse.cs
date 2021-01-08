using GemBot.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemBot.Response
{
    public class MasterDataResponse
    {
        public List<GemType> GemType { get; set; }
        public List<GemClarity> GemClarity { get; set; }
        public List<GemColor> GemColor { get; set; }
        public List<GemColorShade> GemColorShade { get; set; }
        public List<GemCut> GemCut { get; set; }
        public List<GemFineshedType> GemFineshedType { get; set; }
        public List<GemOrigin> GemOrigin { get; set; }
        public List<GemShape> GemShape { get; set; }
        public List<GemSizeRange> GemSizeRange { get; set; }
        public List<GemTreatment> GemTreatment { get; set; }
        public List<GemParcelType> GemParcelType { get; set; }

    }
}
