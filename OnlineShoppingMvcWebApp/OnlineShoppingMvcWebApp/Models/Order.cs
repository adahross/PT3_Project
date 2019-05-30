using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class Order
    {

        public int OrderId { get; set; }
        public List<Cart> Carts { get; set; }

        [Required]
        [Display(Name = "Payment Type", Prompt = "Payment Type")]
        public String PaymentType { get; set; }


        [Display(Name = "Total Price", Prompt = "Total Price")]
        public double TotalPrice { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Order Date", Prompt = "Order Date")]
        public DateTime Date { get; set; }


        [Display(Name = "Shipping Fee", Prompt = "Shipping Fee")]
        public double ShipFee { get; set; }


       
        [ForeignKey("Customer")]
        public int OrderCustomerid { get; set; }
        public virtual Customer Customer {get; set; }


    }
}