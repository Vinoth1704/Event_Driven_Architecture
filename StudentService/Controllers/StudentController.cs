using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentService.Models;
using StudentService.Services;

namespace StudentService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private IStudentsService _studentsService;

        public StudentController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student == null) return BadRequest();
            _studentsService.CreateStudent(student);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_studentsService.GetAllStudents());
        }

        [HttpGet]
        public IActionResult GetParticularStudent(int studentID)
        {
            return Ok(_studentsService.GetParticularStudent(studentID));
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            try
            {
                return Ok(_studentsService.UpdateStudent(student));
            }
            catch
            {
                throw;
            }
        }
        [HttpPatch]
        public IActionResult UpdateParticularStudentField(int id,JsonPatchDocument<Student> student)
        {
            try
            {
                return Ok(_studentsService.UpdateParticularStudentField(id, student));
            }
            catch
            {
                throw;
            }
        }

    }
}