﻿using System;
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

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "PostCode")]
        public string PostCode { get; set; }
    }
}