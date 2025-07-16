using System.ComponentModel.DataAnnotations;

namespace RegisterForm.Models
{
    public class StudentModel
    {
        public int Sid {  get; set; }
        [Required]
        public string? Name {  get; set; }
        [Required]
        [EmailAddress]
        public string? Email {  get; set; }
        [Required]
        [RegularExpression(@"^[789]\d{9}",ErrorMessage="Phone number start with 7,8,9 only 10 digits")]
        public long ContactNumber {  get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Course { get; set; }
        public List<string>? Hobbies { get; set; }
        public List<string>? Skills { get; set; }

        public string hobbies => string.Join(",", Hobbies ?? new List<string>());

        public string skillls=>string.Join(",",Skills ?? new List<string>());

      

    }
}
