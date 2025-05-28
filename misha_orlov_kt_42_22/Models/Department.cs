using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace misha_orlov_kt_42_22.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название кафедры обязательно")]
        [StringLength(150, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime FoundationDate { get; set; }

        public int? HeadId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Teacher? Head { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public bool IsValidDepartmentName()
        {
            var regex = new Regex(@"^Кафедра [а-яё0-9№.,«»""–—\-'\/s]+(имени [А-ЯЁA-Z][а-яёa-zA-ZЁ\-\. ]+)?$");
            return regex.IsMatch(Name);
        }
    }
}
