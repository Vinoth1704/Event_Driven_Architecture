using SubjectService.DAL;
using SubjectService.Models;

namespace SubjectService.Services
{
    public class StudentService : IStudentService
    {
        private IStudentDAL _studentDAL;
        public StudentService(IStudentDAL studentDAL)
        {
            _studentDAL = studentDAL;
        }
        public bool CreateStudent(Student student)
        {
            try
            {
                _studentDAL.CreateStudent(student);
            }
            catch
            {
                throw;
            }
            return true;
        }
    }

}