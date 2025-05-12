using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using misha_orlov_kt_42_22.Models;
using misha_orlov_kt_42_22.Services;
using Microsoft.EntityFrameworkCore;

namespace misha_orlov_kt_42_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkloadsController : ControllerBase
    {
        private readonly IWorkloadService _workloadService;

        public WorkloadsController(IWorkloadService workloadService)
        {
            _workloadService = workloadService;
        }

        [HttpPost("list")]
        public async Task<ActionResult<List<Workload>>> GetWorkloads([FromBody] WorkloadFilter filter)
        {
            var workloads = await _workloadService.GetWorkloadsAsync(filter);

            return Ok(workloads);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Workload>> AddWorkload([FromBody] Workload workload)
        {
            var added = await _workloadService.AddWorkloadAsync(workload);
            return CreatedAtAction(nameof(GetWorkloadById), new { id = added.Id }, added);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Workload>> UpdateWorkload([FromBody] Workload workload)
        {
            var updated = await _workloadService.UpdateWorkloadAsync(workload);
            return Ok(updated);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workload>> GetWorkloadById(int id)
        {
            var workload = await _workloadService.GetWorkloadByIdAsync(id);
            if (workload == null)
                return NotFound();
            return Ok(workload);
        }
    }
}
