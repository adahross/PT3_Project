using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class RegisteredUser
    {
        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Name = "User ID", Prompt = "Please fill in")]
        public int registeredUserId { get; set; }


        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Name = "Full Name", Prompt = "Please fill in")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Name = "User Name", Prompt = "Please fill in")]
        [StringLength(15, ErrorMessage = "Password atleast 5 characters, MinimumLength = 5")]
        public string userName { get; set; }


        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Name = "Password", Prompt = "Please fill in")]
        [StringLength(15, ErrorMessage = "Password atleast 3 characters, MinimumLength = 3")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        public string role { get; set; }
    }
}