using System.ComponentModel.DataAnnotations;
namespace WebEFDbCurd.Models
{
    public class EmpModel
    {
        [Key]
        public int Empid { get; set; }

        [Required]
        public string Ename { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
