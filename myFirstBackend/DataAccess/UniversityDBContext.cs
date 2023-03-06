using Microsoft.EntityFrameworkCore;
using myFirstBackend.Models.DataModels;

namespace myFirstBackend.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }

        // TODO: Add DbSets (Tables of our Data Base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Category>? Categorias { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Student>? Students { get; set; }

    }
}
