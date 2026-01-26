

namespace ManagementSystem.DomainModels
{
    public class Employees
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public string UserName { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        public string Phone { get; set; } = string.Empty;
        
        public string  DepartmentName{get; set;}= string.Empty;
        
        public string Specailty { get; set;}= string.Empty;

        //==============1:M Realationships===========
        public int DepartmentId {  get; set; }
        public Departments? Department { get; set; }

        //================M:1 Relationship 
        public ICollection<Requests>? Requests { get; set; } = new List<Requests>();


    }
}
