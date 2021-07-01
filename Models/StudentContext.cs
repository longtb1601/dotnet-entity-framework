using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students {get; set;}
    }
}