using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class Book
    {
        [Required(ErrorMessage = "Cannot left blank")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        public string Year { get; set; }

        [Display(Name = "Cover Page")]
        public string CoverPage { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        public double Price { get; set; }


    }
}