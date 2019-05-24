using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [Required (ErrorMessage ="Cannot left blank")]
        [Display(Prompt = "Please fill in")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Please fill in")]
        public string State { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Please fill in")]
        public string City { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Please fill in")]
        public string Country { get; set; }

        [Required (ErrorMessage ="Cannot left blank")]
        [Display(Prompt = "Please fill in")]
        public string PostCode { get; set; }
    }
}