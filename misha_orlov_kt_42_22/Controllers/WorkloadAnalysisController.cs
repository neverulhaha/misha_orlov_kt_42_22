using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using misha_orlov_kt_42_22.Services;
using misha_orlov_kt_42_22.Services.Filters;

namespace misha_orlov_kt_42_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkloadAnalysisController : ControllerBase
    {
        private readonly IWorkloadAnalysisService _workloadAnalysisService;

        public WorkloadAnalysisController(IWorkloadAnalysisService workloadAnalysisService)
        {
            _workloadAnalysisService = workloadAnalysisService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentWorkloadSummary>>> GetSummary([FromQuery] WorkloadAnalysisFilter filter)
        {
            var summary = await _workloadAnalysisService.GetDepartmentWorkloadSummaryAsync(filter);
            return Ok(summary);
        }
    }
}
