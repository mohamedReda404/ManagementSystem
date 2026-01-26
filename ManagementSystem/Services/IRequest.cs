

namespace ManagementSystem.Services
{
    public interface IRequest
    {
        Task<Requests> Get(int id);
        Task<Requests> Add(Requests request);
        Task<bool> Delete(int id);
        Task<List<RequestDTO>> GetAll();
        
    }
}
