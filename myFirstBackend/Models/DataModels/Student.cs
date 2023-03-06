using System.ComponentModel.DataAnnotations;

namespace myFirstBackend.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        public string Lastname { get; set; } = string.Empty;
        [Required]
        public DateTime Dob { get; set; }
        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
    };
}
