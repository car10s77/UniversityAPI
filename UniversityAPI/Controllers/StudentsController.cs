using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> students = _studentRepository.GetAllStudents();
            return students.Count > 0 ?
                Ok(students): NoContent();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            Student student = _studentRepository.GetStudentById(id);

            return student != null ? Ok(student) : NoContent();
        }

        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            Student _student = _studentRepository.CreateStudent(student);
            return _student != null ?
                Created("api/Student/Create", new { Student = _student}): this.StatusCode(500);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            Student _student = _studentRepository.UpdateStudent(id, student);

            return _student!= null ? Ok(_student): this.StatusCode(500);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _studentRepository.DeleteStudent(id)? 
                Ok() : this.StatusCode(500);
        }

        [HttpGet("course/{courseId}")]
        public IActionResult GetStudentsInCourse(int courseId)
        {
            var _students = _studentRepository.GetStudentsByCourse(courseId);

            return _students!= null && _students.Count > 0 ?
                Ok(_students) : NoContent();
        }
    }
}
