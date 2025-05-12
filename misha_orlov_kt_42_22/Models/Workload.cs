using System.ComponentModel.DataAnnotations;

namespace misha_orlov_kt_42_22.Models
{
    public class Workload
    {
        public int Id { get; set; }

        public int? TeacherId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Teacher? Teacher { get; set; }

        public int? SubjectId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Subject? Subject { get; set; }

        [Required(ErrorMessage = "Количество часов обязательно")]
        [Range(1, 1000, ErrorMessage = "Часы должны быть от 1 до 1000")]
        public int Hours { get; set; }
    }
}
