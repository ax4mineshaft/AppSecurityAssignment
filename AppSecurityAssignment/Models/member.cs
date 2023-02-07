
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace AppSecurityAssignment.Models
{
    public class member:IdentityUser
    {

        [Required]
        public string fullName{ get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string emailAddress { get; set; }
        [Required]
        [DataType(DataType.CreditCard, ErrorMessage ="Invalid Credit Card Number")]
        public string creditCardNo { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Invalid Phone Number.")]

        public string phoneNo { get; set; }
        [Required]
        public string deliveryAddress { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(password), ErrorMessage = "Password and confirmation password does not match")]
        public string passwordcfm { get; set; }
        
        public string? photo { get; set; }
        
        public string? aboutMe { get; set; }




    }
}
