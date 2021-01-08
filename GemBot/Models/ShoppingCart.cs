using System;
using System.Collections.Generic;

namespace GemBot.Models
{
    public partial class ShoppingCart
    {
        public int? Id { get; set; }
        public Guid? Cartid { get; set; }
        public string Userid { get; set; }
        public int? Productid { get; set; }
        public DateTime? CDate { get; set; }
        public int? Quantity { get; set; }
    }
}
