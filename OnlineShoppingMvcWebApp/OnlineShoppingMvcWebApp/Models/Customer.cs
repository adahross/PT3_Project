using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcWebApp.Models
{
    public class Customer : RegisteredUser
    {
        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Phone Number")]
        [StringLength(12, ErrorMessage = "Phone Number must be between 9 to 11 numbers", MinimumLength = 9)]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

       

        public int ShipAddressID { get; set; }
        [ForeignKey("ShipAddressID")]
         [Required(ErrorMessage = "Cannot left blank")]
        [Display(Prompt = "Shipment Address")]
        public virtual Address ShipAddress { get; set; }


        public string GetUsername() {

            return userName;
        }
        public string GetPassword()
        {

            return password;
        }

    }
}