using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class Cart
    {
        public int cartID { get; set; }


        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }

    public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }
        

        
        public int Quantity { get; set; }

        public Cart(Book book, int quantity)
        {
            Book = book;
            Quantity = quantity;


        }
    }
}