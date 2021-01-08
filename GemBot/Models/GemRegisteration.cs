using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class GemRegisteration
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
