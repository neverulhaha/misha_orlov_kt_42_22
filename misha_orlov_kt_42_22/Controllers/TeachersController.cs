using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using misha_orlov_kt_42_22.Models;
using misha_orlov_kt_42_22.Services;

namespace misha_orlov_kt_42_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("list")]
        public async Task<ActionResult<List<Teacher>>> GetTeachers([FromBody] TeacherFilter filter)
        {
            var teachers = await _teacherService.GetTeachersAsync(filter);
            return Ok(teachers);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Teacher>> AddTeacher([FromBody] Teacher teacher)
        {
            // Обнуляем вложенные объекты, чтобы не создавать их заново
            teacher.Department = null;
            teacher.Degree = null;
            teacher.Position = null;
            // Удаляем строку обнуления Workloads, так как свойства нет в модели

            teacher.Id = 0; // reset id for new entity
            var added = await _teacherService.AddTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = added.Id }, added);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Teacher>> UpdateTeacher([FromBody] Teacher teacher)
        {
            // Обнуляем вложенные объекты, чтобы не создавать их заново
            teacher.Department = null;
            teacher.Degree = null;
            teacher.Position = null;
            // Удаляем строку обнуления Workloads, так как свойства нет в модели

            var updated = await _teacherService.UpdateTeacherAsync(teacher);
            return Ok(updated);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            var deleted = await _teacherService.DeleteTeacherAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);
        }
    }
}
