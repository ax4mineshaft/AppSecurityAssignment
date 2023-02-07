using System.ComponentModel.DataAnnotations;

namespace AppSecurityAssignment.Models
{
	public class login
	{
        [Required]
        [DataType(DataType.EmailAddress)]
        public string loginEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string loginPassword { get; set; }
        public bool RememberMe { get; set; }

    }
}
