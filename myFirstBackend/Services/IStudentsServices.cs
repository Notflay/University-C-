using myFirstBackend.Models.DataModels;

namespace myFirstBackend.Services
{
    public interface IStudentsServices
    {
        IEnumerable<Student> GetStudentWithCursos();
        IEnumerable<Student> GetStudentWithNoCursos();
    }
}
