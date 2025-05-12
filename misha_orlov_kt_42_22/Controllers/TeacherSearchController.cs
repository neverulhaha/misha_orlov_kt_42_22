using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using misha_orlov_kt_42_22.Models;
using misha_orlov_kt_42_22.Services;
using misha_orlov_kt_42_22.Services.Filters;

namespace misha_orlov_kt_42_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherSearchController : ControllerBase
    {
        private readonly ITeacherSearchService _teacherSearchService;

        public TeacherSearchController(ITeacherSearchService teacherSearchService)
        {
            _teacherSearchService = teacherSearchService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> Search([FromQuery] TeacherSearchFilter filter)
        {
            var teachers = await _teacherSearchService.SearchTeachersAsync(filter);
            return Ok(teachers);
        }
    }
}
