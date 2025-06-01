using System.Collections.Generic;

namespace MvcCoreCurd2.Models
{
    public class EmpViewModel
    {
        public int Eid { get; set; }
        public string Ename { get; set; }
        public double Salary {  get; set; }
        public string Gender { get; set; }
       // public string Department { get; set; }
        public List<string> SelectedHobbies { get; set; } // Stores selected hobbies
        public List<string> City { get; set; }  // Dropdown List
        public List<string> Hobbies { get; set; }  // List of all available hobbies
    }
}
