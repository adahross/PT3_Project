using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingMvcWebApp.Models;

namespace OnlineShoppingMvcWebApp.ViewModels
{
    public class ShoppingCart
    {
        public virtual Book Book { get; set; }
    
       
        public List<Order> Order { get; set; }
        public ShoppingCart()
        {
            Order = new List<Order>();
        }
    }
}