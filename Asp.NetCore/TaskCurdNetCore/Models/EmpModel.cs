using System.ComponentModel.DataAnnotations;

namespace TaskCurdNetCore.Models
{
    public class EmpModel
    {
        public int Eid {  get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]+$",ErrorMessage ="First name Should Contain only letters")]
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? Gender { get; set; }
        
        [Required]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.[a-zA-Z]{2,4}$",ErrorMessage ="Invalid Email format")]
        public string? Email {  get; set; }
        [Required]
        [RegularExpression(@"^[789]\d{9}$",ErrorMessage ="mobile number should start with 7,8,9 & 10 digits only ")]
        public long Mobile { get; set; }


    }
}
