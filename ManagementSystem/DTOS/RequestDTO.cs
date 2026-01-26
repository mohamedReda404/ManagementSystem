namespace ManagementSystem.DTOS
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string MployeeName { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Salry { get; set; }
        public bool Approved { get; set; }
        public int EmployeeId { get; set; }
    }
}
