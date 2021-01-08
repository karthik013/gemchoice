using GemBot.Helper;
using GemBot.Models;
using log4net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    {

    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        log.Info("Inside Authenticator");
       
        GemdbContext gemdbContext = null;
        GemRegisteration gemRegisteration = null;
        string key = string.Empty;
        string decryptedPassword = string.Empty;

        if (string.IsNullOrEmpty(Request.Headers["Authorization"]))
            return AuthenticateResult.Fail("Missing Authorization Header");

        try
        {
            gemdbContext = new GemdbContext();
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            log.InfoFormat("Inside Authenticator : {0}", Request.Headers["Authorization"]);
            var authData = authHeader.Parameter.Split(string.Empty);
            log.InfoFormat("Token {0}",authData.Length);
            log.InfoFormat("postion of a[0] : {0}",authData[0]);
            var credentialBytes = Convert.FromBase64String(authData[0]);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
            var emailId = credentials[0];
            var password = credentials[1];

            
           gemRegisteration = gemdbContext.GemRegisteration.Find(emailId);
           //gemRegisteration = new GemRegisteration();
           //gemRegisteration.EmailId = "rafiq@gamil.com";

            if (gemRegisteration != null)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                key = config["Login:key"];
                decryptedPassword = SecureData.DecryptString(gemRegisteration.Password, key);

                if (emailId.ToLower() == gemRegisteration.EmailId.ToLower() && password == decryptedPassword)
                {
                    var claims = new Claim[] { new Claim(ClaimTypes.Name, gemRegisteration.EmailId) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Invalid token");
                }
            }
            else
            {
                log.Info("invalid token ");
                return AuthenticateResult.Fail("Invalid token");
            }
        }
        catch(Exception ex)
        {
            log.ErrorFormat("Exception occured {0}",ex);
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }
    }
}