using System.Collections.Generic;
using System.Threading.Tasks;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Services
{
    public class WorkloadFilter
    {
        public int? TeacherId { get; set; }
        public int? DepartmentId { get; set; }
        public int? SubjectId { get; set; }
    }

    public interface IWorkloadService
    {
        Task<List<Workload>> GetWorkloadsAsync(WorkloadFilter filter);
        Task<Workload?> GetWorkloadByIdAsync(int id);
        Task<Workload> AddWorkloadAsync(Workload workload);
        Task<Workload> UpdateWorkloadAsync(Workload workload);
    }
}
