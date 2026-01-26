

namespace ManagementSystem.DomainModels
{
    public class Requests
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;   
        public string ManagerName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Salary { get; set; }    
        public bool Approved { get; set; }
        // 1:M Relationship
        public int EmployeeId { get; set; }
        public Employees? Employee { get; set; }
    }
}
