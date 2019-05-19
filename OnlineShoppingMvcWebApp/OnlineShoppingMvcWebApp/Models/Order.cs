using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class Order
    {

        public int OrderId{ get; set; }
        public  String PaymentType { get; set; }
        public double TotalPrice { get; set; }
        public double ShipFee { get; set; }
        public Customer Customer { get; set; }

    }
}