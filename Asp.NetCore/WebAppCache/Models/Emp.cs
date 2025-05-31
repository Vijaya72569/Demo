﻿using System.ComponentModel.DataAnnotations;

namespace WebAppCache.Models
{
    public class Emp
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string Ename { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
