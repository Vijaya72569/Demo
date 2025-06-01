using System.ComponentModel.DataAnnotations;
namespace WebAppAssign.Models
{
    public class Emp
    {
        [Required]
        public int Eno { get; set; }
        [Required]
        public string Ename { get; set; }

        [Required]
        public string Job { get; set; }
        [Required]
        public double Sal { get; set; }
        
        public int Commision { get; set; }

        public double TotalSal { get; set; }



    }
}
