using System.ComponentModel.DataAnnotations;

namespace misha_orlov_kt_42_22.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название предмета обязательно")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Workload> Workloads { get; set; } = new List<Workload>();
    }
}
