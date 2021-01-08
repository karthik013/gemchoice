using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GemBot.CustomModel;
using GemBot.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GemBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    //FileUpload/UploadGemImages/{productId}
    public class FileUploadController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        GemdbContext gemdbContext = null;
        [HttpPost]
        [Route("UploadGemImages/{productId}")]
        public async Task<IActionResult> UploadImages([FromForm] GemImagesModel gemImagesModel, string productId)
        {
            log.Info("Inside File Upload");
            Dictionary<string, string> fileNames = new Dictionary<string, string>();
            string filePath = string.Empty;

            //foreach (var files in gemImagesModel)
            //{
            if (productId != null)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

                filePath = config["Files:ImagesPath"] + "\\" + productId;
                log.InfoFormat("File Path {0}", filePath);
                try
                {
                    if (!Directory.Exists(filePath))
                    {
                        log.Info("Directory Created successfully");
                        Directory.CreateDirectory(filePath);
                    }

                    if (gemImagesModel.GemFrontView != null)
                    {
                        log.Info("GemFrontView adding started successfully");
                        filePath = filePath + "\\" + gemImagesModel.GemFrontView.FileName;
                        using (FileStream filestream = System.IO.File.Create(filePath))
                        {
                            fileNames.Add("GemFrontView", filePath);

                            gemImagesModel.GemFrontView.CopyTo(filestream);
                            filestream.Flush();

                            gemdbContext = new GemdbContext();
                            var data = gemdbContext.GemMasterProducts.Find(productId);
                            data.GemFrontView = filePath;
                            gemdbContext.SaveChanges();
                            log.InfoFormat("GemFrontView adding completed successfully path is {0}", filePath);
                        }
                    }
                    if (gemImagesModel.GemProfile != null)
                    {
                        log.Info("GemProfile adding started successfully");
                        filePath = config["Files:ImagesPath"] + "\\" + productId + "\\" + gemImagesModel.GemProfile.FileName;
                        using (FileStream filestream = System.IO.File.Create(filePath))
                        {
                            fileNames.Add("GemProfile", filePath);
                            gemImagesModel.GemProfile.CopyTo(filestream);
                            filestream.Flush();

                            gemdbContext = new GemdbContext();
                            var data = gemdbContext.GemMasterProducts.Find(productId);
                            data.GemProfile = filePath;
                            gemdbContext.SaveChanges();
                            log.InfoFormat("GemProfile adding completed successfully path is {0}", filePath);
                        }
                    }
                    if (gemImagesModel.GemTopView != null)
                    {
                        log.Info("GemTopView adding started successfully");
                        filePath = config["Files:ImagesPath"] + "\\" + productId + "\\" + gemImagesModel.GemTopView.FileName;
                        using (FileStream filestream = System.IO.File.Create(filePath))
                        {
                            fileNames.Add("GemTopView", filePath);
                            gemImagesModel.GemTopView.CopyTo(filestream);
                            filestream.Flush();

                            gemdbContext = new GemdbContext();
                            var data = gemdbContext.GemMasterProducts.Find(productId);
                            data.GemTopView = filePath;
                            gemdbContext.SaveChanges();
                            log.InfoFormat("GemTopView adding completed successfully path is {0}", filePath);
                        }
                    }
                    if (gemImagesModel.GemVideo != null)
                    {
                        log.Info("GemVideo adding started successfully");
                        filePath = config["Files:ImagesPath"] + "\\" + productId + "\\" + gemImagesModel.GemVideo.FileName;
                        using (FileStream filestream = System.IO.File.Create(filePath))
                        {
                            fileNames.Add("GemVideo", filePath);
                            gemImagesModel.GemVideo.CopyTo(filestream);
                            filestream.Flush();

                            gemdbContext = new GemdbContext();
                            var data = gemdbContext.GemMasterProducts.Find(productId);
                            data.GemVideo = filePath;
                            gemdbContext.SaveChanges();
                            log.InfoFormat("GemVideo adding completed successfully path is {0}", filePath);
                        }
                    }
                    if (gemImagesModel.GemSideView != null)
                    {
                        log.Info("GemSideView adding started successfully");
                        filePath = config["Files:ImagesPath"] + "\\" + productId + "\\" + gemImagesModel.GemSideView.FileName;
                        using (FileStream filestream = System.IO.File.Create(filePath))
                        {
                            fileNames.Add("GemSideView", filePath);
                            gemImagesModel.GemSideView.CopyTo(filestream);
                            filestream.Flush();

                            gemdbContext = new GemdbContext();
                            var data = gemdbContext.GemMasterProducts.Find(productId);
                            data.GemSideView = filePath;
                            gemdbContext.SaveChanges();
                            log.InfoFormat("GemSideView adding completed successfully path is {0}", filePath);
                        }
                    }

                    if (gemImagesModel.GemCertificate != null)
                    {
                        log.Info("GemSideView adding started successfully");
                        filePath = config["Files:ImagesPath"] + "\\" + productId + "\\" + gemImagesModel.GemCertificate.FileName;
                        using (FileStream filestream = System.IO.File.Create(filePath))
                        {
                            fileNames.Add("GemCertificate", filePath);
                            gemImagesModel.GemCertificate.CopyTo(filestream);
                            filestream.Flush();

                            gemdbContext = new GemdbContext();
                            var data = gemdbContext.GemMasterProducts.Find(productId);
                            data.GemCertificate = filePath;
                            gemdbContext.SaveChanges();
                            log.InfoFormat("GemCertificate adding completed successfully path is {0}", filePath);
                        }
                    }

                    if (gemImagesModel.GemColorVariation != null)
                    {
                        log.Info("GemSideView adding started successfully");
                        filePath = config["Files:ImagesPath"] + "\\" + productId + "\\" + gemImagesModel.GemColorVariation.FileName;
                        using (FileStream filestream = System.IO.File.Create(filePath))
                        {
                            fileNames.Add("GemColorVariation", filePath);
                            gemImagesModel.GemColorVariation.CopyTo(filestream);
                            filestream.Flush();

                            gemdbContext = new GemdbContext();
                            var data = gemdbContext.GemMasterProducts.Find(productId);
                            data.GemColorVariation = filePath;
                            gemdbContext.SaveChanges();
                            log.InfoFormat("GemColorVariation adding completed successfully path is {0}", filePath);
                        }
                    }

                    log.Info("File added successfully");
                    return (Ok(fileNames.ToList()));
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("execpetion occured while uploading the images {0}", ex);
                    return BadRequest("Internal error occured contact administrator");
                }
            }
            else
            {
                log.InfoFormat("Bad Request");
                return BadRequest("Unsuccessful");
            }

        }
    }

}
