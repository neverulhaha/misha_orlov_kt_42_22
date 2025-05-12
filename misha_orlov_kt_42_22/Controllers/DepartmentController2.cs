using Microsoft.AspNetCore.Mvc;
using misha_orlov_kt_42_22.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace misha_orlov_kt_42_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Department2Controller : ControllerBase
    {
        private readonly IDepartment2Service _service;

        public Department2Controller(IDepartment2Service service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<string>>> GetDepartmentsByPosition([FromQuery] string positionName)
        {
            if (string.IsNullOrWhiteSpace(positionName))
            {
                return BadRequest("Необходимо указать название должности.");
            }

            var departments = await _service.GetDepartmentsByPositionAsync(positionName);

            if (departments == null || departments.Count == 0)
            {
                return NotFound("Кафедры не найдены.");
            }

            return Ok(departments);
        }
    }
}
