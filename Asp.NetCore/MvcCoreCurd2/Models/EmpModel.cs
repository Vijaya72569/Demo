using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCoreCurd2.Models
{
    public class EmpModel
    {
        [Key]
        public int Eid { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(10, ErrorMessage = "Name cannot be longer than 10 characters")]
        public string Ename { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "City selection is required")]
        public string City { get; set; }

         public string Hobbies { get; set; } // Store selected hobbies as a comma-separated string
      
        
        // public List<string> Hobbies { get; set; } = new List<string>();
    }

}

