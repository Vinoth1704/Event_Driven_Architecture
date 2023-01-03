using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using StudentService.DataAccessLayer;
using StudentService.Models;

namespace StudentService.Services
{
    public class StudentsService : IStudentsService
    {
        private IStudentDAL _studentDAL;
        private IMessagingService _messageService;
        public StudentsService(IStudentDAL studentDAL, IMessagingService messageService)
        {
            _studentDAL = studentDAL;
            _messageService = messageService;
        }
        public bool CreateStudent(Student student)
        {
            try
            {
                _studentDAL.CreateStudent(student);
                string studentDetails = JsonConvert.SerializeObject(new
                {
                    StudentID = student.StudentID,
                    StudentName = student.StudentName
                });
                _messageService.SendMessage(studentDetails);
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
                return _studentDAL.GetAllStudents();
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
                return _studentDAL.GetParticularStudent(StudentID);
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateStudent(Student student)
        {
            try
            {
                return _studentDAL.UpdateStudent(student);
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
                return _studentDAL.UpdateParticularStudentField(id, student);
            }
            catch
            {
                throw;
            }
        }

    }
}