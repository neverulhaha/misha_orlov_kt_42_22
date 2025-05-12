using Microsoft.Extensions.DependencyInjection;
using misha_orlov_kt_42_22.Services;

namespace misha_orlov_kt_42_22
{
    public static class ServiceExtensions
    {
        public static void AddDepartmentServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IWorkloadService, WorkloadService>();
            services.AddScoped<ITeacherSearchService, TeacherSearchService>();
            services.AddScoped<IDepartment2Service, Department2Service>();
            services.AddScoped<IWorkloadAnalysisService, WorkloadAnalysisService>();
        }
    }
}
