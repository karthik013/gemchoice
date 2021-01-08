using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Threading.Tasks;
using GemBot.Helper;
using GemBot.Models;
using log4net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GemBot.Controllers
{

    // var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    // string sqlConn = config["Database:DbCon"];
    // log.InfoFormat("Sql Connection string is  {0}", sqlConn);
    //  optionsBuilder.UseSqlServer(sqlConn);
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        GemdbContext gemdbContext = null;
        string key = string.Empty;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        [HttpPost]
        [Route("ValidateUser")]

        public IActionResult ValidateUser(Login login)
        {
            log.Info("Inside login method");
            string decryptedPassword = string.Empty;
            string auth = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(login.Email) && !string.IsNullOrEmpty(login.Password))
                {
                    log.InfoFormat("The given email Id is  {0}", login.Email);
                    gemdbContext = new GemdbContext();
                    var response = gemdbContext.GemRegisteration.Find(login.Email);

                    if (response != null && !string.IsNullOrEmpty(login.Password))
                    {
                        log.InfoFormat("The given login Id is found {0}", login.Email);
                        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                        key = config["Login:key"];
                        decryptedPassword = SecureData.DecryptString(response.Password, key);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                    if (login.Email.ToLower() == response.EmailId.ToLower() && decryptedPassword == login.Password)
                    {
                        LoginResponse loginResponse = new LoginResponse();
                        loginResponse.FirstName = response.FirstName;
                        loginResponse.LastName = response.LastName;
                        loginResponse.EmailId = response.EmailId;
                        auth = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(login.Email + ":" + login.Password));
                        loginResponse.token = auth;
                        log.InfoFormat("login successfully completed for the user : {0} and generated token is ", login.Email, loginResponse.token);
                        return Ok(loginResponse);
                    }
                    else
                    {
                        log.InfoFormat("Unauthorized user :{0}", login.Email);
                        return Unauthorized();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error occured : {0}", ex);
                return BadRequest("Unable to proceed further. please contact administrator");
            }
        }
    }
}
