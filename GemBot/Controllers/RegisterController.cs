using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GemBot.Helper;
using GemBot.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GemBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        GemdbContext gemdbContext = null;
        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser(GemRegisteration registeration)
        {
            string key = string.Empty
                ;
            GemRegisteration gemRegisteration = new GemRegisteration();
            try
            {
                if (registeration.FirstName != null && registeration.LastName != null && registeration.EmailId != null && registeration.Password != null && registeration.PhoneNumber != null)
                {
                    gemdbContext = new GemdbContext();

                    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                    key = config["Login:key"];
                    registeration.Password = SecureData.EncryptString(registeration.Password, key);
                  
                    var data = gemdbContext.GemRegisteration.Add(registeration);
                    gemdbContext.SaveChanges();
                    return Created("Created",registeration.EmailId);
                }
                else
                {
                    return BadRequest("Invalid Data");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("VOILATION"))
                {
                    return BadRequest("Email Id is Already Registered");
                }
                else
                {
                    return BadRequest("Techical difficulties. Contact Adminstrator");
                }
            }
        }
    }
}
