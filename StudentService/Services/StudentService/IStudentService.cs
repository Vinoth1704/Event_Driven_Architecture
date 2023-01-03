using Microsoft.AspNetCore.JsonPatch;
using StudentService.Models;

namespace StudentService.Services
{
    public interface IStudentsService
    {
        public bool CreateStudent(Student student);
        public IEnumerable<Student> GetAllStudents();
        public IEnumerable<Student> GetParticularStudent(int StudentID);
        public bool UpdateStudent(Student student);
        public bool UpdateParticularStudentField(int id, JsonPatchDocument<Student> student);
    }
}