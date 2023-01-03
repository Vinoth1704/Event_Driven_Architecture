using SubjectService.Models;

namespace SubjectService.DAL
{
    public interface IStudentDAL
    {
        public bool CreateStudent(Student student);
    }

}