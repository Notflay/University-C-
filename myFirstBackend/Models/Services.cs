using myFirstBackend.DataAccess;
using myFirstBackend.Models.DataModels;

namespace myFirstBackend.Models
{
    public class Services
    {

        Chapter chapter = new Chapter();


        public void imprimirChaper()
        {
            Console.WriteLine(chapter.Id);
            Console.Read();
        }

    }
}
