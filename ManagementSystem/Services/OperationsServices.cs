
namespace ManagementSystem.Services
{
    public class OperationsServices(ApplicationDbContext context) : IOperation
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<Operations> Add(Operations request)
        {
            //_context.Entry(request).Reference(r => r.Description).IsModified = false;
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<bool> Delete(int id)
        {
            var currentRequests = await Get(id);

            if (currentRequests == null)
                return false;

            _context.operations.Remove(currentRequests);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Operations> Get(int id)
        {
            return await _context.operations.FindAsync(id);
        }

        public async Task<List<OperationDTO>> GetAll()
        {
            return await _context.operations
               .Select(d => new OperationDTO
               {
                   Id = d.Id,
                   Name = d.Name,
                   Description = d.Description,
                  
               })
               .ToListAsync();
        }
    }
}
