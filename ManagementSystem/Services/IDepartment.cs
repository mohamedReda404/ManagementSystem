

namespace ManagementSystem.Services
{
    public interface IDepartment
    {
        Task<Departments> Get(int id);
        Task<Departments> AddAsync(Departments department);
        Task<bool> Delete(int id);
        Task<List<DpatmentDTO>> GetAll();
    }
}
