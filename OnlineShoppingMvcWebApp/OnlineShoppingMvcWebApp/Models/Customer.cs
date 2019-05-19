using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class Customer:RegisteredUser
    {

        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public Address ShipAddress { get; set; }

    }
}