using System.Collections.Generic;
using System.ComponentModel;

namespace MvcCoreCurdOperations.Models
{
    public class EmployeeViewModel
    {
        public List<EmpModel> Employeelist { get; set; }
        public EmpModel SelectedEmplyee { get; set; }

    }
}
