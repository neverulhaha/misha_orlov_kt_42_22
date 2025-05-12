using System.ComponentModel.DataAnnotations;

namespace misha_orlov_kt_42_22.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [StringLength(50)]
        public string? Patronymic { get; set; }

        public int? DepartmentId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Department? Department { get; set; }

        public int? DegreeId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public AcademicDegree? Degree { get; set; }

        public int? PositionId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Position? Position { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Workload> Workloads { get; set; } = new List<Workload>();
    }
}
