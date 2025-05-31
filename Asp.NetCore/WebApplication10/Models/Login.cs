using System.ComponentModel.DataAnnotations;
namespace WebApplication10.Models
{
    public class Login
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
