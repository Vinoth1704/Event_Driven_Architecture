using Microsoft.EntityFrameworkCore;
using StudentService.Models;

namespace StudentService.DataAccessLayer
{
    public class StudentServiceDBContext : DbContext
    {
        public StudentServiceDBContext(DbContextOptions<StudentServiceDBContext> options) : base(options)
        {

        }
        public DbSet<Student>? Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
        .Property(p => p.StudentID)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn(100,2);
        }
    }
}