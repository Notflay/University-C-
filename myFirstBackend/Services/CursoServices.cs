using myFirstBackend.Models.DataModels;

namespace myFirstBackend.Services
{
    public class CursoServices : ICursosServices
    {
        public IEnumerable<Curso> GetCursosCat(Curso[] cursos)
        {
            return from curso in cursos
                   where curso.Objetivos.Count() > 0
                   select curso;
        }
    }
}
