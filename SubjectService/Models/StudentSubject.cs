namespace SubjectService.Models
{
    public class StudentSubject
    {

        public int StudentSubjectID { get; set; }
        public int StudentID { get; set; }
        public Student? student { get; set; }
        public int SubjectID { get; set; }
        public Subject? subject { get; set; }
    }
}