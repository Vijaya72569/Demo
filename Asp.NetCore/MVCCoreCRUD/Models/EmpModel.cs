using System.ComponentModel.DataAnnotations;

namespace MVCCoreCRUD.Models
{
    public class EmpModel
    {
        [Key]
        [Required(ErrorMessage ="Empid is Required")]
        public int Eid { get; set; }
        [Required (ErrorMessage ="Name is Required")]
        [StringLength (50)]
        public string Ename { get; set; }
        [Required]
        [Range(0,double.MaxValue,ErrorMessage ="Salary must be Positive")]
        public double Salary { get; set; }

        [Required (ErrorMessage ="Gender is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage ="City is Required")]
        public string City { get; set; }
        [Required(ErrorMessage ="Hobbies Required")]
        public string Hobbies { get; set; }
       
    }
}
