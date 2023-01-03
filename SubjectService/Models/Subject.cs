using System.ComponentModel.DataAnnotations;

namespace SubjectService.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string? SubjectName { get; set; }
        public virtual ICollection<StudentSubject>? studentSubjects { get; set; }
    }
}