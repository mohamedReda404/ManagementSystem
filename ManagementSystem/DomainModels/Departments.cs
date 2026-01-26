
namespace ManagementSystem.DomainModels
{
    public class Departments
    {
        
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        //============M:1 Relationship=======
        [JsonIgnore]
        public ICollection<Employees> Employee { get; set; }= new List<Employees>();

    }
}
