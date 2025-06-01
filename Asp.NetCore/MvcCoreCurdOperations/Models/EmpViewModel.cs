using System.Collections.Generic;

namespace MvcCoreCurdOperations.Models
{
    public class EmpViewModel
    {
        public List<EmpModel> Employeelist { get; set; }
        public EmpModel SelectedEmplyee { get; set; }
    }
}
