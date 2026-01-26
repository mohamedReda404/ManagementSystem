

namespace ManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController(IRequest request) : ControllerBase
    {
        private readonly IRequest _request = request;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = await _request.Get(id);
            if (request == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(request);
            }
        }




        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = new Requests
            {
                Id = dto.Id,
                EmployeeName = dto.MployeeName,
                ManagerName = dto.ManagerName,
                DepartmentName = dto.DepartmentName,
                Description = dto.Description,
                Salary = dto.Salry,
                Approved = dto.Approved,
                EmployeeId = dto.EmployeeId
            };

            var saved = await _request.Add(request);
            return Ok(saved);
        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _request.Delete(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _request.GetAll();
            return Ok(result);
        }



    }
}
