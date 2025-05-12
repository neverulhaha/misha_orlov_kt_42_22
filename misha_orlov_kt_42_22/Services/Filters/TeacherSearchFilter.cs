using System;

namespace misha_orlov_kt_42_22.Services.Filters
{
    public class TeacherSearchFilter
    {
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public int? DegreeId { get; set; }
        public int? SubjectId { get; set; }
        public int? MinWorkloadHours { get; set; }
        public int? MaxWorkloadHours { get; set; }
    }
}
