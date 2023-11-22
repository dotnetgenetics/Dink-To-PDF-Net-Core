namespace DinkToPDFNetCore.Model
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Dependent> DependentsList { get; set; }

        public EmployeeViewModel()
        {
            Employee = new Employee();
            DependentsList = new List<Dependent>();
        }
    }

    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpStatus { get; set; }

        public Employee()
        {
            EmpID = 0;
            EmpName = string.Empty;
            EmpStatus = string.Empty;
        }
    }

    public class Dependent
    {
        public int DepID { get; set; }
        public string DepName { get; set; }
        public int DepAge { get; set; }

        public Dependent()
        {
            DepID = 0;
            DepAge = 0;
            DepName = string.Empty;
        }
    }
}
