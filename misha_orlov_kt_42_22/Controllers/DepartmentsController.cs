using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using misha_orlov_kt_42_22.Models;
using misha_orlov_kt_42_22.Services;

namespace misha_orlov_kt_42_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("list")]
        public async Task<ActionResult<List<Department>>> GetDepartments([FromBody] DepartmentFilter filter)
        {
            var departments = await _departmentService.GetDepartmentsAsync(filter);
            return Ok(departments);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Department>> AddDepartment([FromBody] Department department)
        {
            department.Head = null;
            department.Teachers = null;

            department.Id = 0;

            var added = await _departmentService.AddDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = added.Id }, added);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Department>> UpdateDepartment([FromBody] Department department)
        {
            var updated = await _departmentService.UpdateDepartmentAsync(department);
            return Ok(updated);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var deleted = await _departmentService.DeleteDepartmentAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }
    }
}
