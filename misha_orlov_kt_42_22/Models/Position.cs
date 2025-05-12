using System.ComponentModel.DataAnnotations;

namespace misha_orlov_kt_42_22.Models
{
    public class Position
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название должности обязательно")]
        [StringLength(100, MinimumLength = 3)]
        public string PositionName { get; set; } = null!;

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
