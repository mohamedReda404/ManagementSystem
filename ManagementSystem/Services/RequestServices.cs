


namespace ManagementSystem.Services
{
    public class RequestServices(ApplicationDbContext context) : IRequest
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<Requests> Add(Requests request)
        {
            _context.Entry(request).Reference(r => r.Employee).IsModified = false;
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<bool> Delete(int id)
        {
            var currentRequests = await Get(id);

            if (currentRequests == null)
                return false;

            _context.requests.Remove(currentRequests);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Requests> Get(int id)
        {
            return await _context.requests.FindAsync(id);
        }


        public async Task<List<RequestDTO>> GetAll()
        {
            return await _context.requests
                .Select(d => new RequestDTO
                {
                    Id = d.Id,
                    MployeeName = d.EmployeeName,
                    ManagerName = d.ManagerName,
                    Salry=d.Salary,
                })
                .ToListAsync();
        }

    }
}
