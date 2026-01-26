

namespace ManagementSystem.Services
{
    
    public class EmployeeSrvices(ApplicationDbContext context) : IEmployee
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Employees> Add(EmployeeDTO Employee)
        {
            var emp=await _context.departments.AnyAsync(d=>d.Id== Employee.DepartmentId);
            var employee = new Employees
            {
                Id = Employee.Id,
                Name = Employee.Name, 
                DepartmentId = Employee.DepartmentId,
            };
            _context.employees.Add(employee);
          await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> Delete(int id)
        {
            var currentEmployee = await Get(id);

            if (currentEmployee == null)
                return false;

            _context.employees.Remove(currentEmployee);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Employees> Get(int id)
        {
            return await _context.employees.FindAsync(id);
        }

        public async Task<List<EmployeeDTO>> GetAll()
        {
            return await _context.employees
                .Select(d => new EmployeeDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                })
                .ToListAsync();
        }
    }
}
