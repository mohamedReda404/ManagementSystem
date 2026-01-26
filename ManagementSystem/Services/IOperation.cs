namespace ManagementSystem.Services
{
    public interface IOperation
    {
        Task<Operations> Get(int id);
        Task<Operations> Add(Operations request);
        Task<bool> Delete(int id);
        Task<List<OperationDTO>> GetAll();
    }
}
