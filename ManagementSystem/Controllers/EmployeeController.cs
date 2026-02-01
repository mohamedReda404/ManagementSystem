

namespace ManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployee employee ) : ControllerBase
    {
        private readonly IEmployee _Employee = employee;


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var employee = await _Employee.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeDTO empolyee)
        {
            try
            {
                var emp = await _Employee.Add(empolyee);
                return Ok(emp);
            }
            catch (Exception ex) { 
             return BadRequest(ex.Message);
            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _Employee.Delete(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _Employee.GetAll();
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edite(int id)
        {
            var deleted = await _Employee.Delete(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }

    }
}
