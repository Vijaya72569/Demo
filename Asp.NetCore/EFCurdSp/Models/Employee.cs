using System.ComponentModel.DataAnnotations;

namespace EFCurdSp.Models
{
    public class Employee
    {
        [Key]
        public int EId { get; set; }
        public string? Name { get; set; }
        public decimal Salary {  get; set; }
    }
}
