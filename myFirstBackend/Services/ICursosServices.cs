using myFirstBackend.Models.DataModels;

namespace myFirstBackend.Services
{
    public interface ICursosServices
    {
        IEnumerable<Curso> GetCursosCat(Curso[] cursos);
    }
}
