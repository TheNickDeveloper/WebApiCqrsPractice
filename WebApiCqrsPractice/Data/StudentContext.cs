using Microsoft.EntityFrameworkCore;
using WebApiCqrsPractice.Models;

namespace WebApiCqrsPractice.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext (DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}
