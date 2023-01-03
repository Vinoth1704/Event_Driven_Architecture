using Microsoft.EntityFrameworkCore;
using SubjectService.Models;

namespace SubjectService.DAL
{
    public class SubjectServiceDBContext : DbContext
    {
        public SubjectServiceDBContext(DbContextOptions<SubjectServiceDBContext> options) : base(options)
        {

        }
        public DbSet<Subject>? subjects { get; set; }
        public DbSet<Student>? student { get; set; }
        public DbSet<StudentSubject>? studentSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.studentSubjects).WithOne(s => s.student).HasForeignKey(s => s.StudentID);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.studentSubjects).WithOne(s => s.subject).HasForeignKey(s => s.SubjectID);
        }
    }
}