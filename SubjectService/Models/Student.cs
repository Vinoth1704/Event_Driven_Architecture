using System.ComponentModel.DataAnnotations;

namespace SubjectService.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public virtual ICollection<StudentSubject>? studentSubjects { get; set; }
    }
}