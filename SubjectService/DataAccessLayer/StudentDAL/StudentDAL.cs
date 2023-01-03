using SubjectService.Models;

namespace SubjectService.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private SubjectServiceDBContext _db;
        public StudentDAL(SubjectServiceDBContext subjectServiceDB)
        {
            _db = subjectServiceDB;
        }
        public bool CreateStudent(Student student)
        {
            _db.student!.Add(student);
            _db.SaveChanges();
            return true;
        }
    }

}
