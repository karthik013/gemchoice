using GemBot.Models;
using GemBot.Response;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//Scaffold-DbContext "Data Source=IN1LT1164\SQLEXPRESS;Initial Catalog=Gemdb;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force

//Scaffold-DbContext "Data Source=IN1LT1164\SQLEXPRESS;Initial Catalog=Gemdb;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
namespace GemBot.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class GemController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        GemdbContext gemdbContext = null;

        private readonly ILogger<GemController> _logger;
        public GemController(ILogger<GemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("MasterData")]
        public ActionResult GetMasterData()
        {
            try
            {
                log.InfoFormat("Inside Get Master data");
                gemdbContext = new GemdbContext();
                MasterDataResponse masterDataResponse = new MasterDataResponse();
                masterDataResponse.GemType = gemdbContext.GemType.ToList<GemType>();
                masterDataResponse.GemFineshedType = gemdbContext.GemFineshedType.ToList<GemFineshedType>();
                masterDataResponse.GemOrigin = gemdbContext.GemOrigin.ToList<GemOrigin>();
                masterDataResponse.GemShape = gemdbContext.GemShape.ToList<GemShape>();
                masterDataResponse.GemTreatment = gemdbContext.GemTreatment.ToList<GemTreatment>();
                masterDataResponse.GemCut = gemdbContext.GemCut.ToList<GemCut>();
                masterDataResponse.GemSizeRange = gemdbContext.GemSizeRange.ToList<GemSizeRange>();
                masterDataResponse.GemColor = gemdbContext.GemColor.ToList<GemColor>();
                masterDataResponse.GemColorShade = gemdbContext.GemColorShade.ToList<GemColorShade>();
                masterDataResponse.GemClarity = gemdbContext.GemClarity.ToList<GemClarity>();
                masterDataResponse.GemParcelType = gemdbContext.GemParcelType.ToList<GemParcelType>();
                return Ok(masterDataResponse);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpGet]
        [Route("ValidateProduct/{productId}")]
        public ActionResult ValidateProductId(string productId)
        {
            try
            {
                log.InfoFormat("Inide Validate ProductId {0}", productId);
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemMasterProducts.Where(data => data.GeneratedRefId == productId).ToList<GemMasterProducts>();
                if (data.Count > 0 && data[0].GeneratedRefId == productId)
                {
                    log.InfoFormat("Product Id :{0} is found", productId);
                    return Ok();
                }
                else
                {
                    return NotFound(string.Format("Product Id is not found : {0}", productId));
                }
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }

        // GET: api/<GemController>
        [HttpGet]
        [Route("GetGemOrigin")]
        public ActionResult GetOrigin()
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemOrigin.ToArray<GemOrigin>();
                return Ok(data);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // GET api/<GemController>/5
        [HttpGet]
        [Route("GetGemOrigin /{id}")]
        public ActionResult GemOriginByLocation(int id)
        {
            try
            {
                gemdbContext = new GemdbContext();
                string gemType = gemdbContext.GemOrigin.Find(id).Origin;
                return Ok(gemType);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpGet]
        [Route("GetGemShape")]
        public ActionResult GetGemShapes()
        {
            try
            {
                log.Info("Inside Gem Size");
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemShape.ToArray<GemShape>();
                log.Info("SUCCESS");
                return Ok(data);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetGemSize")]
        public ActionResult GetGemSize()
        {
            try
            {
                log.Info("Inside Gem Size");
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemSizeRange.ToArray<GemSizeRange>();
                var shape = gemdbContext.GemShape.ToArray<GemShape>();
                List<GemSizeResponse> gemShapeList = new List<GemSizeResponse>();
                for (int i = 0; i < data.Length; i++)
                {
                    GemSizeResponse gemSizeResponse = new GemSizeResponse();
                    gemSizeResponse.Id = data[i].Id;
                    gemSizeResponse.Size = data[i].Size;
                    gemSizeResponse.IsActive = data[i].IsActive;
                    gemSizeResponse.CDate = data[i].CDate;
                    gemSizeResponse.UDate = data[i].UDate;
                    //shade.GemColor = gemdbContext.GemColor.Find(data[i].Id).Color;

                    for (int j = 0; j < shape.Count(); j++)
                    {
                        if (data[i].GemShape == shape[j].Id)
                        {
                            gemSizeResponse.GemShape = shape[j].Shape;
                            break;
                        }
                    }

                    gemShapeList.Add(gemSizeResponse);
                }
                log.Info("SUCCESS");

                log.InfoFormat("SUCCESS");
                return Ok(gemShapeList);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("GetGemColor")]
        public ActionResult GetGemColor()
        {
            try
            {
                log.Info("Inside Gem color API");
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemColor.ToArray<GemColor>();
                return Ok(data);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetGemShade")]
        public ActionResult GetGemColorShade()
        {
            try
            {
                log.Info("INSIDE - GEM Color shade");
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemColorShade.ToArray<GemColorShade>();
                var color = gemdbContext.GemColor.ToArray<GemColor>();
                List<GemColorShadeResponse> colorShadeList = new List<GemColorShadeResponse>();
                for (int i = 0; i < data.Length; i++)
                {
                    GemColorShadeResponse shade = new GemColorShadeResponse();
                    shade.Id = data[i].Id;
                    shade.Shade = data[i].Shade;
                    shade.IsActive = data[i].IsActive;
                    shade.CDate = data[i].CDate;
                    shade.UDate = data[i].UDate;
                    //shade.GemColor = gemdbContext.GemColor.Find(data[i].Id).Color;

                    for (int j = 0; j < color.Count(); j++)
                    {
                        if (data[i].GemColor == color[j].Id)
                        {
                            shade.GemColor = color[j].Color;
                            break;
                        }
                    }

                    colorShadeList.Add(shade);
                }
                log.Info("SUCCESS");
                return Ok(colorShadeList);

            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpGet]
        [Route("GetGemType")]
        public ActionResult GetGemType()
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemType.ToArray<GemType>();
                log.Info("SUCCESS");
                return Ok(data);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpGet]
        [Route("GetGemTreatment")]
        public ActionResult GetGemTreatment()
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemTreatment.ToArray<GemTreatment>();
                log.Info("SUCCESS");
                return Ok(data);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpGet]
        [Route("GetGemClarity")]
        public ActionResult GetGemClarity()
        {
            try
            {
                log.Info("INSIDE Gem Clarity");
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemClarity;
                log.Info("SUCCESS");
                return Ok(data.ToArray<GemClarity>());
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpGet]
        [Route("GetGemCut")]
        public ActionResult GetGemCut()
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemCut.ToArray<GemCut>();
                return Ok(data);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpGet]
        [Route("GetGemCert/{certificateId}")]

        public ActionResult GetGemCert(int certificateId)
        {
            try
            {
                log.Info("Insede GemCetificate");
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemCert.Find(certificateId).Name;
                log.Info("SUCCESS");
                return Ok(data);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetGemFineshedType")]
        public ActionResult GetFineshedType()
        {
            try
            {
                log.InfoFormat("Inside Fineshed Type");
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemFineshedType.ToArray<GemFineshedType>();
                log.InfoFormat("SUCCESS");
                return Ok(data);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpPost]
        [Route("AddGemProduct")]
        public ActionResult AddGemProduct(GemMasterProducts gemProduct)
        {
            try
            {
                gemdbContext = new GemdbContext();
                gemProduct.CDate = DateTime.Now;
                gemProduct.GeneratedRefId = gemProduct.GemType + "-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                var data = gemdbContext.GemMasterProducts.Add(gemProduct);
                gemdbContext.SaveChanges();
                return Created("GemProduct", gemProduct);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpGet]
        [Route("GetProductList")]
        public ActionResult GetProductList()
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemMasterProducts.ToList<GemMasterProducts>();
                return Ok(data);
            }
            catch (Exception ex)
            {
                log.InfoFormat("exeception occeured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("AddGemColor")]
        public ActionResult CreateNewColor(GemColor gemColor)
        {
            try
            {
                _logger.LogInformation("Inside add color");
                gemdbContext = new GemdbContext();
                gemColor.CDate = DateTime.Now;
                var data = gemdbContext.GemColor.Where<GemColor>(color => color.Color == gemColor.Color);
                if (data.Count() == 0)
                {
                    var datares = gemdbContext.GemColor.Add(gemColor);
                    gemdbContext.SaveChanges();
                    return Created("Gem color added successfully", gemColor);
                }
                else
                {
                    return BadRequest("Color is already exist");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY "))
                {
                    BadRequest("Already Exist");
                }
                _logger.LogError("Exception occured while creating the color {0}", ex);
                return BadRequest("Unable to save the data please contact the adminitrator!!");
            }
        }

        [HttpPost]
        [Route("AddGemShade")]
        public ActionResult CreateColorShade(GemColorShade gemColorShade)
        {
            try
            {
                _logger.LogInformation("Inside add color shade");
                gemdbContext = new GemdbContext();
                gemColorShade.CDate = DateTime.Now;
                var data = gemdbContext.GemColorShade.Add(gemColorShade);
                gemdbContext.SaveChanges();
                return Created("Gem color shade added successfully", gemColorShade);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY "))
                {
                    BadRequest("Already Exist");
                }
                _logger.LogError("Exception occured while creating the color shade {0}", ex);
                return BadRequest("Unable to save the data please contact the administrator!!");
            }
        }

        [HttpPost]
        [Route("AddGemCut")]
        public ActionResult CreateGemCut(GemCut gemCut)
        {
            try
            {
                _logger.LogInformation("Inside add cut");
                gemdbContext = new GemdbContext();
                gemCut.CDate = DateTime.Now;
                var data = gemdbContext.GemCut.Add(gemCut);
                gemdbContext.SaveChanges();
                return Created("Gem cut added successfully", gemCut);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY "))
                {
                    BadRequest("Already Exist");
                }
                _logger.LogError("Exception occured while creating the gem cut {0}", ex);
                return BadRequest("Unable to save the data please contact the administrator!!");
            }
        }

        [HttpPost]
        [Route("AddGemClarity")]
        public ActionResult CreateClarity(GemClarity gemClarity)
        {
            try
            {
                _logger.LogInformation("Inside add clarity");
                gemdbContext = new GemdbContext();
                gemClarity.CDate = DateTime.Now;
                var data = gemdbContext.GemClarity.Add(gemClarity);
                gemdbContext.SaveChanges();
                return Created("Gem clarity added successfully", gemClarity);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY "))
                {
                    BadRequest("Already Exist");
                }
                _logger.LogError("Exception occured while creating the color {0}", ex);
                return BadRequest("Unable to save the data please contact the administrator!!");
            }
        }

        [HttpPost]
        [Route("AddGemFineshed")]
        public ActionResult CreateGemName(GemFineshedType gemFineshedType)
        {
            try
            {
                _logger.LogInformation("Inside add name");
                gemdbContext = new GemdbContext();
                gemFineshedType.CDate = DateTime.Now;
                var data = gemdbContext.GemFineshedType.Add(gemFineshedType);
                gemdbContext.SaveChanges();
                return Created("Gem name added successfully", gemFineshedType);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY "))
                {
                    BadRequest("Already Exist");
                }
                _logger.LogError("Exception occured while creating the gem name {0}", ex);
                return BadRequest("Unable to save the data please contact the administrator!!");
            }
        }


        [HttpPost]

        [Route("AddGemOrigin")]
        public ActionResult CreateOrigin(GemOrigin gemOrigin)
        {
            try
            {
                _logger.LogInformation("Inside add gem origin");
                gemdbContext = new GemdbContext();
                gemOrigin.CDate = DateTime.Now;
                var data = gemdbContext.GemOrigin.Add(gemOrigin);
                gemdbContext.SaveChanges();
                return Created("Gem cut added successfully", gemOrigin);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY "))
                {
                    BadRequest("Already Exist");
                }
                _logger.LogError("Exception occured while creating the gem origin {0}", ex);
                return BadRequest("Unable to save the data please contact the administrator!!");
            }
        }


        [HttpPost]
        [Route("AddGemShape")]
        public ActionResult CreateShape(GemShape gemShape)
        {
            try
            {
                _logger.LogInformation("Inside add gem shape");
                gemdbContext = new GemdbContext();
                gemShape.CDate = DateTime.Now;
                var data = gemdbContext.GemShape.Add(gemShape);
                gemdbContext.SaveChanges();
                return Created("Gem cut added successfully", gemShape);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY "))
                {
                    BadRequest("Already Exist");
                }
                _logger.LogError("Exception occured while creating the gem shape {0}", ex);
                return BadRequest("Unable to save the data please contact the administrator!!");
            }
        }

        [HttpPost]
        [Route("AddGemSize")]
        public ActionResult CreateGemSize(GemSizeRange gemSizeRange)
        {
            try
            {
                _logger.LogInformation("Inside add gem size range");
                gemdbContext = new GemdbContext();
                gemSizeRange.CDate = DateTime.Now;

                var data = gemdbContext.GemSizeRange.ToArray<GemSizeRange>();
                var shape = gemdbContext.GemShape.ToArray<GemShape>();

                List<GemSizeResponse> gemShapeList = new List<GemSizeResponse>();
                for (int i = 0; i < data.Length; i++)
                {
                    GemSizeResponse gemSizeResponse = new GemSizeResponse();
                    gemSizeResponse.Id = data[i].Id;
                    gemSizeResponse.Size = data[i].Size;
                    gemSizeResponse.IsActive = data[i].IsActive;
                    gemSizeResponse.CDate = data[i].CDate;
                    gemSizeResponse.UDate = data[i].UDate;
                    //shade.GemColor = gemdbContext.GemColor.Find(data[i].Id).Color;

                    for (int j = 0; j < shape.Count(); j++)
                    {
                        if (data[i].GemShape == shape[j].Id)
                        {
                            gemSizeResponse.GemShape = shape[j].Shape;
                            break;
                        }
                    }

                    gemShapeList.Add(gemSizeResponse);
                }
                log.Info("SUCCESS");

                gemdbContext.GemSizeRange.Add(gemSizeRange);
                gemdbContext.SaveChanges();
                return Created("Gem cut added successfully", gemShapeList);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY "))
                {
                    BadRequest("Already Exist");
                }
                _logger.LogError("Exception occured while creating the gem shape {0}", ex);
                return BadRequest("Unable to save the data please contact the administrator!!");
            }
        }

        [HttpPost]
        [Route("AddGemTreatment")]
        public ActionResult CreateGemTreatment(GemTreatment gemTreatment)
        {
            try
            {
                _logger.LogInformation("Inside add gem size range");
                gemdbContext = new GemdbContext();
                gemTreatment.CDate = DateTime.Now;
                var data = gemdbContext.GemTreatment.Add(gemTreatment);
                gemdbContext.SaveChanges();
                return Created("Gem cut added successfully", gemTreatment);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY "))
                {
                    BadRequest("Already Exist");
                }
                _logger.LogError("Exception occured while creating the gem shape {0}", ex);
                return BadRequest("Unable to save the data please contact the administrator!!");
            }
        }

        [HttpDelete]
        [Route("DeleteGemSize/{sizeId}")]
        public ActionResult DeleteSize(string sizeId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemSizeRange.Find(sizeId);
                if (data != null)
                {
                    gemdbContext.GemSizeRange.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Size doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }

        [HttpPut]
        [Route("UpdateGemSize/{sizeId}")]
        public ActionResult UpdateSize(int sizeId, [FromBody] JObject dataObj)
        {
            log.Info("Inside delete for Size");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemSizeRange.Find(sizeId);
                if (data.Size != null && !string.IsNullOrEmpty(dataObj["Size"].ToString()))
                {
                    data.Size = dataObj["Size"].ToString();
                    data.IsActive = Convert.ToBoolean(dataObj["isActive"]);
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();
                    var dataRes = gemdbContext.GemSizeRange.Where<GemSizeRange>(size => size.Id == sizeId);
                    return Ok(dataRes);
                }
                else
                {
                    return BadRequest("Size doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }

        [HttpDelete]
        [Route("DeleteGemShape/{shapeId}")]
        public ActionResult DeleteShape(int shapeId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemShape.Find(shapeId);
                if (data != null)
                {
                    gemdbContext.GemShape.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Shape doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }

        [HttpPut]
        [Route("UpdateGemShape/{shapeId}")]
        public ActionResult UpdateShape(int shapeId, [FromBody] JObject dataObj)
        {
            log.Info("Inside delete for Size");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemShape.Find(shapeId);
                if (data.Shape != null && !string.IsNullOrEmpty(dataObj["Shape"].ToString()))
                {
                    data.Shape = dataObj["Shape"].ToString();
                    data.IsActive = Convert.ToBoolean(dataObj["isActive"]);
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();
                    var dataRes = gemdbContext.GemShape.Where<GemShape>(shape => shape.Id == shapeId);
                    return Ok(dataRes);
                }
                else
                {
                    return BadRequest("Shape doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }
        [HttpDelete]
        [Route("DeleteGemColor/{colorId}")]
        public ActionResult DeleteColor(int colorId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemColor.Find(colorId);
                if (data != null)
                {
                    gemdbContext.GemColor.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Gem color doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }

        [HttpPut]
        [Route("UpdateGemColor/{colorId}")]
        public ActionResult UpdateColor(int colorId, [FromBody] JObject dataObj)
        {
            log.Info("Inside delete for Size");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemColor.Find(colorId);
                //var colorShade = gemdbContext.GemColorShade.Where<GemColorShade>(colorValue => colorValue.GemColor.Equals(data.Color));
                if (data.Color != null && !string.IsNullOrEmpty(dataObj["Color"].ToString()))
                {
                    data.Color = dataObj["Color"].ToString();
                    data.IsActive = Convert.ToBoolean(dataObj["isActive"]);
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();
                    var resData = gemdbContext.GemColor.Find(colorId);
                    return Ok(resData);
                }
                else
                {
                    log.InfoFormat("Color doesn't exist");
                    return BadRequest(string.Format("Color  doesn't exist"));
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }

        [HttpDelete]

        [Route("DeleteGemColorShade/{colorShadeId}")]
        public ActionResult DeleteColorShade(int colorShadeId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemColorShade.Find(colorShadeId);
                if (data != null)
                {
                    gemdbContext.GemColorShade.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("ColorShade doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
                //return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        [Route("UpdateGemShade/{colorShadeId}")]
        public ActionResult UpdateColorShade(int colorShadeId, [FromBody] JObject dataObj)
        {
            log.Info("Inside delete for Shade");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemColorShade.Find(colorShadeId);
                if (data.Shade != null && !string.IsNullOrEmpty(dataObj["Shade"].ToString()))
                {
                    data.Shade = dataObj["Shade"].ToString();
                    data.GemColor = Convert.ToInt32(dataObj["GemColor"]);
                    data.IsActive = Convert.ToBoolean(dataObj["isActive"]);
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();
                    var dataRes = gemdbContext.GemColorShade.Find(colorShadeId);
                    return Ok(dataRes);
                }
                else
                {
                    return BadRequest("Color Shade doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }

        [HttpDelete]
        [Route("DeleteGemOrigin/{originId}")]
        public ActionResult DeleteOrigin(int originId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemOrigin.Find(originId);
                if (data != null)
                {
                    gemdbContext.GemOrigin.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("ColorShade doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
                //return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateGemOrigin/{originId}")]
        public ActionResult UpdateOrigin(int originId, [FromBody] JObject dataObj)
        {
            log.Info("Inside delete for Size");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemOrigin.Find(originId);
                if (data.Origin != null && !string.IsNullOrEmpty(dataObj["Origin"].ToString()))
                {
                    data.Origin = dataObj["Origin"].ToString();
                    data.IsActive = Convert.ToBoolean(dataObj["isActive"]);
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();

                    var dataRes = gemdbContext.GemOrigin.Find(originId);
                    return Ok(dataRes);
                }
                else
                {
                    return BadRequest("Origin doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }

        [HttpDelete]
        [Route("DeleteGemType/{typeId}")]
        public ActionResult DeleteGemType(int typeId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemType.Find(typeId);
                if (data != null)
                {
                    gemdbContext.GemType.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("ColorShade doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
                //return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateGemType/{typeId}")]
        public ActionResult UpdateGemType(int typeId, [FromBody] JObject dataObj)
        {
            log.Info("Inside Method : Gem Type");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemType.Find(typeId);
                if (data.Type != null && !string.IsNullOrEmpty(dataObj["GemType"].ToString()))
                {
                    data.Type = dataObj["GemType"].ToString();
                    data.IsActive = Convert.ToBoolean(dataObj["isActive"]);
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();
                    var dataRes = gemdbContext.GemType.Find(typeId);
                    return Ok(dataRes);
                }
                else
                {
                    return BadRequest("type doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }

        [HttpDelete]
        [Route("DeleteGemTreatment/{treatmentId}")]
        public ActionResult DeleteGemTreatement(int treatmentId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemTreatment.Find(treatmentId);
                if (data.Treatment != null)
                {
                    gemdbContext.GemTreatment.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("ColorShade doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateGemTreatment/{treatmentId}")]
        public ActionResult UpdateGemTreatment(int treatmentId, [FromBody] JObject dataObj)
        {
            log.Info("Inside Method : Gem Type");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemTreatment.Find(treatmentId);
                if (data.Treatment != null && !string.IsNullOrEmpty(dataObj["Treatment"].ToString()))
                {
                    data.Treatment = dataObj["Treatment"].ToString();
                    data.IsActive = Convert.ToBoolean(dataObj["isActive"]);
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();
                    var dataRes = gemdbContext.GemTreatment.Find(treatmentId);
                    return Ok(dataRes);
                }
                else
                {
                    return BadRequest("type doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }

        [HttpDelete]
        [Route("DeleteGemFineshedType/{fineshTypeId}")]
        public ActionResult DeleteFineshedType(int fineshTypeId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemFineshedType.Find(fineshTypeId);
                if (data.FineshedType != null)
                {
                    gemdbContext.GemFineshedType.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("ColorShade doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateGemFineshedType/{fineshedTypeId}")]
        public ActionResult UpdateFineshedType(int fineshedTypeId, [FromBody] JObject dataObj)
        {
            log.Info("Inside Method : Gem Type");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemFineshedType.Find(fineshedTypeId);
                if (data.FineshedType != null && !string.IsNullOrEmpty(dataObj["FineshedType"].ToString()))
                {
                    data.FineshedType = dataObj["FineshedType"].ToString();
                    data.IsActive = Convert.ToBoolean(dataObj["isActive"]);
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();
                    var dataRes = gemdbContext.GemTreatment.Find(fineshedTypeId);
                    return Ok();
                }
                else
                {
                    return BadRequest("Finehsed Type doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteGemCut/{cutId}")]
        public ActionResult DeleteCut(int cutId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemCut.Find(cutId);
                if (data.Cut != null)
                {
                    gemdbContext.GemCut.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("ColorShade doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateGemCut/{cutId}")]
        public ActionResult UpdateCut(int cutId, [FromBody] JObject dataObj)
        {
            log.Info("Inside Method : Gem Cut");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemCut.Find(cutId);
                if (data.Cut != null && !string.IsNullOrEmpty(dataObj["Cut"].ToString()))
                {
                    data.Cut = dataObj["Cut"].ToString();
                    data.IsActive = Convert.ToBoolean(dataObj["isActive"]);
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();
                    var dataRes = gemdbContext.GemCut.Find(cutId);
                    return Ok(dataRes);
                }
                else
                {
                    return BadRequest("gem cut doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteGemClarity/{clarityId}")]
        public ActionResult DeleteClarity(int clarityId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemClarity.Find(clarityId);
                if (data.Clarity != null)
                {
                    gemdbContext.GemClarity.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Color Clarity doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateGemClarity/{clarityId}")]
        public ActionResult UpdateClarity(int clarityId, [FromBody] JObject dataObj)
        {
            log.Info("Inside Method : Gem Clarity");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemClarity.Find(clarityId);
                if (data.Clarity != null && !string.IsNullOrEmpty(dataObj["Clarity"].ToString()))
                {
                    data.Clarity = dataObj["Clarity"].ToString();
                    data.IsActive = Convert.ToBoolean(dataObj["isActive"]);
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();

                    var dataRes = gemdbContext.GemClarity.Find(clarityId);
                    return Ok(dataRes);
                }
                else
                {
                    return BadRequest("gem clarity doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteGemParcel/{parcelId}")]
        public ActionResult DeleteParcel(int parcelId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemParcelType.Find(parcelId);
                if (data.ParceType != null)
                {
                    gemdbContext.GemParcelType.Remove(data);
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Color Clarity doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateGemPracelType/{parcelId}")]
        public ActionResult UpdateParcel(int parcelId, [FromBody] JObject dataObj)
        {
            log.Info("Inside Method : Gem Parcel");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemParcelType.Find(parcelId);
                if (data.ParceType != null && !string.IsNullOrEmpty(dataObj["ParcelType"].ToString()))
                {
                    data.ParceType = dataObj["ParcelType"].ToString();
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();

                    var dataRes = gemdbContext.GemParcelType.Find(parcelId);
                    return Ok(dataRes);
                }
                else
                {
                    return BadRequest("gem clarity doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteGemProduct/{productId}")]
        public ActionResult DeleteProduct(string productId)
        {
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemMasterProducts.Find(productId);
                if (data.GeneratedRefId != null)
                {
                    data.IsActive = false;
                    gemdbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Color Clarity doesn't exist");
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateGemProduct/{ProductId}")]
        public ActionResult UpdateGemProducts(string ProductId, [FromBody] GemMasterProducts gemMasterProducts)
        {
            log.Info("Inside Method : Gem Parcel");
            try
            {
                gemdbContext = new GemdbContext();
                var data = gemdbContext.GemMasterProducts.Find(ProductId);
                if (data.GemType != null)
                {
                    data.CaretWeight = gemMasterProducts.CaretWeight == null ? data.CaretWeight : gemMasterProducts.CaretWeight;
                    data.Clarity = gemMasterProducts.Clarity == null ? data.Clarity : gemMasterProducts.Clarity;
                    data.Color = gemMasterProducts.Color == null ? data.Color : gemMasterProducts.Color;
                    data.Cut = gemMasterProducts.Cut == null ? data.Cut : gemMasterProducts.Cut;
                    data.Name = gemMasterProducts.Name == null ? data.Name : gemMasterProducts.Name;
                    data.Discount = gemMasterProducts.Discount == null ? data.Discount : gemMasterProducts.Discount;

                    data.DiscountCode = gemMasterProducts.DiscountCode == null ? data.DiscountCode : gemMasterProducts.DiscountCode;
                    data.FinishType = gemMasterProducts.FinishType == null ? data.FinishType : gemMasterProducts.FinishType;
                    data.IsActive = gemMasterProducts.IsActive == data.IsActive ? data.IsActive : gemMasterProducts.IsActive;
                    data.LongDescription = gemMasterProducts.LongDescription == null ? data.LongDescription : gemMasterProducts.LongDescription;
                    data.Origin = gemMasterProducts.Origin == null ? data.Origin : gemMasterProducts.Origin;
                    data.PricePerCarat = gemMasterProducts.PricePerCarat == null ? data.PricePerCarat : gemMasterProducts.PricePerCarat;

                    data.PricePerPiece = gemMasterProducts.PricePerPiece == null ? data.PricePerPiece : gemMasterProducts.PricePerPiece;
                    data.ParcelType = gemMasterProducts.ParcelType == null ? data.ParcelType : gemMasterProducts.ParcelType;
                    data.RefNo = gemMasterProducts.RefNo == null ? data.RefNo : gemMasterProducts.RefNo;
                    data.Shade = gemMasterProducts.Shade == null ? data.Shade : gemMasterProducts.Shade;
                    data.Shape = gemMasterProducts.Shape == null ? data.Shape : gemMasterProducts.Shape;
                    data.ShortDescription = gemMasterProducts.ShortDescription == null ? data.ShortDescription : gemMasterProducts.ShortDescription;
                    data.Size = gemMasterProducts.Size == null ? data.Size : gemMasterProducts.Size;
                    data.SizeRange = gemMasterProducts.SizeRange == null ? data.SizeRange : gemMasterProducts.SizeRange;
                    data.Treatment = gemMasterProducts.Treatment == null ? data.Treatment : gemMasterProducts.Treatment;
                    data.UDate = DateTime.Now;
                    gemdbContext.SaveChanges();

                    var dataRes = gemdbContext.GemMasterProducts.Find(gemMasterProducts.GeneratedRefId);
                    return Ok();
                }
                else
                {
                    return BadRequest("gem products doesn't exist");
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("execption occured {0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
