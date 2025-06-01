using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class RegModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}

        [Required]
        public string Gender { get; set;}

        public string City { get; set;}
        public List<SelectListItem> Cities { get; } = new List<SelectListItem>()
        {
            new SelectListItem(){Value="Delhi",Text="Delhi"},
            new SelectListItem(){Value="Chennai",Text="Chennai"},
            new SelectListItem(){Value="Amaravathi",Text="Amaravathi"},
            new SelectListItem(){Value="Pune",Text="Pune"},
            new SelectListItem(){Value="Hydrabad",Text="Hydrabad"}
        };
    }
}
