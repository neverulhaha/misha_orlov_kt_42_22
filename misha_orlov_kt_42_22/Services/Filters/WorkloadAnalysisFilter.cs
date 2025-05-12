using System;

namespace misha_orlov_kt_42_22.Services.Filters
{
    public class WorkloadAnalysisFilter
    {
        public DateTime? DepartmentFoundedAfter { get; set; }
        public DateTime? DepartmentFoundedBefore { get; set; }
        public int? MinHours { get; set; }
        public int? MaxHours { get; set; }
        public int? MinTeachersCount { get; set; }
        public int? MaxTeachersCount { get; set; }
    }
}
