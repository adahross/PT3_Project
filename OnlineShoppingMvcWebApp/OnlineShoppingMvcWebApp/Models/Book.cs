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
        [Display(Prompt = "Book ID")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Publisher")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Year")]
        public string Year { get; set; }

        [Display(Name = "Cover Page")]

        public string CoverPage { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Price")]
        public double Price { get; set; }

    }
}