

namespace ManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartment depatment) : ControllerBase
    {
        private readonly IDepartment _depatment = depatment;




        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var employee = await _depatment.Get(id);
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
        public async Task<IActionResult> Add([FromBody] Departments depatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var emp = await _depatment.AddAsync(depatment);
            return Ok(emp);

        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _depatment.Delete(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }





        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _depatment.GetAll();
            return Ok(result);
        }


    }
}
