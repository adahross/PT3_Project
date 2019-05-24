using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class Order
    {

        public int OrderId { get; set; }
        public List<Cart> Carts { get; set; }

        [Required]
        [Display(Name= "Payment Type", Prompt = "Please fill in")]
        public String PaymentType { get; set; }

      
        [Display(Name = "Total Price", Prompt = "Please fill in")]
        public double TotalPrice { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Order Date", Prompt = "Please fill in")]
        public DateTime Date { get; set; }

        
        [Display(Name = "Shipping Fee", Prompt = "Please fill in")]
        public double ShipFee { get; set; }


        public Customer Customer { get; set; }

    }
}