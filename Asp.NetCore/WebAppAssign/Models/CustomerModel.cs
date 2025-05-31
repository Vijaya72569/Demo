using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssign.Models
{
    public class CustomerModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string City { get; set; }
        public List<SelectListItem> cities { get; } = new List<SelectListItem>()
        {
            new SelectListItem(){Text="Amaravathi",Value="Amaravathi"},
            new SelectListItem(){Text="Vizag",Value="Vizag"},
            new SelectListItem(){Text="Chennai",Value="Chennai"},
            new SelectListItem(){Text="Hydrabad",Value="Hydrabad"}
        };
        
        [Required]
        public string Gender { get; set; }
        // public string Hobbies { get; set; }
        public List<string>SelectedHobbies { get; set; } = new List<string>();

        public List<SelectListItem> Hobbies { get; } = new List<SelectListItem>()
{
    new SelectListItem(){ Text = "Music", Value = "Music" },
    new SelectListItem(){ Text = "Crafts", Value = "Crafts" },
    new SelectListItem(){ Text = "Reading", Value = "Reading" }
};


        //   public bool Music { get; set; }

        //   public bool Crafts { get; set; }
        //   public bool Reading { get; set; }
    }
}
