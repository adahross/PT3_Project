using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; } 
        public string CoverPage { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

       
    }
}