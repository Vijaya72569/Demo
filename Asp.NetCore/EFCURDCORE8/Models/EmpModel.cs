using System.ComponentModel.DataAnnotations;

namespace EFCURDCORE8.Models
{
    public class EmpModel
    {
        [Key]
        public int Eid {  get; set; }
        [Required]
        public string? Ename { get; set; }
        [Required]
        public decimal Salary {  get; set; }
    }
}
