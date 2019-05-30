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
        [Display(Name = "User ID", Prompt = "User ID")]
        public int registeredUserId { get; set; }


        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Name = "Full Name", Prompt = "Full Name")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Name = "User Name", Prompt = "User Name")]
        [StringLength(15, ErrorMessage = "Username atleast 5 characters",MinimumLength =5)]
        public string userName { get; set; }


        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Name = "Password", Prompt = "Password")]
        [StringLength(15, ErrorMessage = "Password atleast 5 characters",MinimumLength =5)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Role")]
        public string role { get; set; }
    }
}