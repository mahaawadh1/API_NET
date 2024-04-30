using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CIVIL ID is Required!!")]
        public int civilId { get; set; }
        [Required(ErrorMessage = "Position is Required!!")]
        public string Position { get; set; }
        public int BankBranchId { get; set; }
        public BankBranch BankBranch { get; set; }
    }
}
