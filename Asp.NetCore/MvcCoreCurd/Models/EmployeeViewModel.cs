using System.Collections.Generic;

namespace MvcCoreCurd.Models
{
    public class EmployeeViewModel
    {
        public List<EmpModel> EmployeeList { get; set; }
        public EmpModel SelectedEmployee { get; set; } = new EmpModel(); // Default empty employee
    }
}

