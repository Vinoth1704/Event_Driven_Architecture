using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using StudentService.Models;

namespace StudentService.DataAccessLayer
{

    public class StudentDAL : IStudentDAL
    {
        private StudentServiceDBContext _db;
        public StudentDAL(StudentServiceDBContext studentServiceDBContext)
        {
            _db = studentServiceDBContext;
        }
        public bool CreateStudent(Student student)
        {
            try
            {
                _db.Add(student);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                return (from Student in _db.Students select Student);
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<Student> GetParticularStudent(int StudentID)
        {
            try
            {
                var student = from Student in _db.Students where Student.StudentID == StudentID select Student;
                Console.WriteLine(student);
                if (student == null)
                    throw new Exception();
                return student;
            }
            catch
            {
                throw new BadHttpRequestException("Student ID not found");
            }
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                Student? students = _db.Students!.Find(student.StudentID);
                if (students == null) throw new BadHttpRequestException("Student ID not found");
                _db.Entry(students).State = EntityState.Detached;
                _db.Students.Update(student);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }

        }
        public bool UpdateParticularStudentField(int id, JsonPatchDocument<Student> student)
        {
            try
            {
                Student? students = _db.Students!.Find(id);
                if (students == null) throw new BadHttpRequestException("Student ID not found");
                _db.Entry(students).State = EntityState.Detached;
                _db.Students.Update(students);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}