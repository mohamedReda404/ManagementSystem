

namespace ManagementSystem.Services
{
    public class DepartmentServices(ApplicationDbContext context) : IDepartment
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<Departments> AddAsync(Departments department)
        {
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> Delete(int id)
        {
            var currentDepartment = await Get(id);

            if (currentDepartment == null)
                return false;

            _context.departments.Remove(currentDepartment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Departments> Get(int id)
        {
            return await _context.departments.FindAsync(id);
        }
        public async Task<List<DpatmentDTO>> GetAll()
        {
            return await _context.departments
                .Select(d => new DpatmentDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    ManagerName = d.ManagerName
                })
                .ToListAsync();
        }
       



    }
}
