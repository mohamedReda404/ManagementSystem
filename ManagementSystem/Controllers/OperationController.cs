

using ManagementSystem.Services;

namespace ManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OperationController(IOperation operation) : ControllerBase
    {
        private readonly IOperation _operation = operation;



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = await _operation.Get(id);
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
        public async Task<IActionResult> Add([FromBody] Operations dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var emp = await _operation.Add(dto);
            return Ok(emp);
        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _operation.Delete(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }




        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _operation.GetAll();
            return Ok(result);
        }




    }
}
