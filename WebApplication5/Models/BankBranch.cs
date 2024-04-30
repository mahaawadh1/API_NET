namespace WebApplication5.Models
{
    public class BankBranch
    { 
        public int Id { get; set; }
        public string location { get; set; }
        public string locationURL { get; set; }
        public string branchManager { get; set; }
        public int employeeCount { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

    public static class BankBranchData
    {
        public static List<BankBranch> BankBranches = new List<BankBranch>
        {
            new BankBranch {Id = 1,   location = "jaber alahmed" , locationURL = "https://maps.app.goo.gl/CTtbQcN6Swd68SF56" , branchManager = "maha" , employeeCount = 40},
            new BankBranch {Id = 2, location = "salmya" , locationURL = "https://maps.app.goo.gl/AGVK5VHgT2Ggaehx6" , branchManager = "amar" , employeeCount = 22}
        };
    }
}