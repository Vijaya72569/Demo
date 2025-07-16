using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RevalsysTask4.Models
{
    public class EmpModel
    {
        public int EmpId { get; set; }
        [Required ( ErrorMessage="FirstName required") ]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string? FirstName {  get; set; }
        [Required(ErrorMessage ="Email required")]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.[a-zA-Z]{2,4}$",ErrorMessage ="Invalid Email")]
       
        public string? Email {  get; set; }
        [RegularExpression(@"^[789]\d{9}$",ErrorMessage ="number must start with 7,8,9 & 10 digits only")]
        [Required]
        public long? Mobile {  get; set; }
        public int CountryId { get; set; }
        public int StateId {  get; set; }
        public string? CountryName { get; set; }
        public string? StateName {  get; set; }
        public List<SelectListItem>? Countries { get; set; }
        public List<SelectListItem>? States { get; set; }
    }
}
