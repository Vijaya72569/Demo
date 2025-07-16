using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RevalsysTask5Course.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        [Required]
        public string? CourseName { get; set; }
        [Required]
        [Remote(action:"CourseCodeValid",controller:"Course")]
        public string? CourseCode { get; set; }
        public string? Description { get;set; }
        public DateTime? CourseStartDate { get; set; }
    }
}
