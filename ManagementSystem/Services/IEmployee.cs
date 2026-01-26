


namespace ManagementSystem.Services
{
    public interface IEmployee
    {
        Task<Employees> Get(int id);
        Task<Employees> Add(EmployeeDTO Employee);
        Task<bool> Delete(int id);
        Task<List<EmployeeDTO>> GetAll();
    }
}
