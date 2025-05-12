using System.Collections.Generic;
using System.Threading.Tasks;
using misha_orlov_kt_42_22.Services.Filters;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Services
{
    public interface IWorkloadAnalysisService
    {
        Task<List<DepartmentWorkloadSummary>> GetDepartmentWorkloadSummaryAsync(WorkloadAnalysisFilter filter);
    }

    public class DepartmentWorkloadSummary
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int TotalHours { get; set; }
        public int SubjectsCount { get; set; }
    }
}
