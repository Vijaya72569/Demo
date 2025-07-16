using System.ComponentModel.DataAnnotations;

namespace NetCoreCurdTask.Models
{
    public class EmpModel
    {
        public int Eid { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]+$",ErrorMessage ="FirstName Can Accept Only letters")]
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.[a-zA-Z]{2,4}$",ErrorMessage ="Invalid Email")]
        public string? Email {  get; set; }
        [Required]
        [RegularExpression(@"^[789]\d{9}",ErrorMessage ="Number Should Start With 7,8,9 & only 10 digits")]
        public long Mobile {  get; set; }
    }
}
