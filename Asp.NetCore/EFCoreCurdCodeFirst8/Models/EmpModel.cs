using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCurdCodeFirst8.Models
{
    [Table("Emps")]
    public class EmpModel
    {
        [Key]
        public int Eid { get; set; }
     
        public string? Name { get; set; }
    
        public double Salary {  get; set; }
    }
}
