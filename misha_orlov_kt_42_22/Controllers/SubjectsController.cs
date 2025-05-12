using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using misha_orlov_kt_42_22.Models;
using misha_orlov_kt_42_22.Services;

namespace misha_orlov_kt_42_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("list")]
        public async Task<ActionResult<List<Subject>>> GetSubjects([FromBody] SubjectFilter filter)
        {
            var subjects = await _subjectService.GetSubjectsAsync(filter);
            return Ok(subjects);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Subject>> AddSubject([FromBody] Subject subject)
        {
            subject.Id = 0; // reset id for new entity
            var added = await _subjectService.AddSubjectAsync(subject);
            return CreatedAtAction(nameof(GetSubjectById), new { id = added.Id }, added);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Subject>> UpdateSubject([FromBody] Subject subject)
        {
            var updated = await _subjectService.UpdateSubjectAsync(subject);
            return Ok(updated);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            var deleted = await _subjectService.DeleteSubjectAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
                return NotFound();
            return Ok(subject);
        }
    }
}
