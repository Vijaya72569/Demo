using System.ComponentModel.DataAnnotations;

namespace WebAppCoreCURD.Models
{
    public class EmpModel
    {
        [Required]
        public int Empid { get; set; }
        [Required]
        public string Ename { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
    }
}
