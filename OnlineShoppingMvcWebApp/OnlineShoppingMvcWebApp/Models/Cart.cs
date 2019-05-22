using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class Cart
    {
        public int cartID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

        public Cart(Book book, int quantity)
        {
            Book = book;
            Quantity = quantity;


        }
    }
}