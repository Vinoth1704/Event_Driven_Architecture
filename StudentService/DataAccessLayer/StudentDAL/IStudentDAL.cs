using Microsoft.AspNetCore.JsonPatch;
using StudentService.Models;

namespace StudentService.DataAccessLayer
{
    public interface IStudentDAL
    {
        public bool CreateStudent(Student student);
        public IEnumerable<Student> GetAllStudents();
        public IEnumerable<Student> GetParticularStudent(int StudentID);

        public bool UpdateStudent(Student student);
        public bool UpdateParticularStudentField(int id, JsonPatchDocument<Student> student);
    }
}