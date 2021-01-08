using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemBot.Models
{
    public class LoginResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string token { get; set; }
    }
}
