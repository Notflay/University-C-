using System.ComponentModel.DataAnnotations;

namespace myFirstBackend.Models.DataModels
{
    public enum NivelCurso
    {
        Basico,
        Intermedio,
        Avanzado
    }
    public class Curso : BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string Descp_corta { get; set; } = string.Empty;
        [Required]
        public string Descp_larga { get; set; } = string.Empty;
        [Required]
        public string Publ_objetivo { get; set; } = string.Empty;
        [Required]
        public string Objetivos { get; set; } = string.Empty;
        [Required]
        public string Requisitos { get; set; } = string.Empty;
        [Required, Range(0, 2)]
        public NivelCurso Nivel { get; set; }
    }
}
