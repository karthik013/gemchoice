using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemBot.CustomModel
{
    public class GemImagesModel
    {
        public IFormFile GemProfile { get; set; }
        public IFormFile GemFrontView { get; set; }
        public IFormFile GemSideView { get; set; }
        public IFormFile GemTopView { get; set; }
        public IFormFile GemVideo { get; set; }
        public IFormFile GemColorVariation { get; set; }
        public IFormFile GemCertificate { get; set; }


    }
}
