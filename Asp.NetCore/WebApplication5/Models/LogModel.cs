using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class LogModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        
    }
}
