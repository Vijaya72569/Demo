﻿using System.ComponentModel.DataAnnotations;

namespace EFCoreDbWebApi.Models
{
    public class EmployModel
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
