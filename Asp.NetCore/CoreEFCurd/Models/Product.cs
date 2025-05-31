using System.ComponentModel.DataAnnotations;

namespace CoreEFCurd.Models
{
    public class Product
    {
        [Key]
        public int Pid { get; set; }
        [Required]
        public string Pname { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
