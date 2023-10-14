using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Models;
using UniversityAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository coursepository)
        {
            _courseRepository = coursepository;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return courses.Count > 0 ?
                Ok(courses) : NoContent();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            Course course = _courseRepository.GetCourseById(id);

            return course != null ? Ok(course) : NoContent();
        }

        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            Course _course = _courseRepository.CreateCourse(course);
            return _course != null ?
                Ok(_course) : this.StatusCode(500);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Course course)
        {
            Course _course = _courseRepository.UpdateCourse(id, course);

            return _course != null ? Ok(_course) : this.StatusCode(500);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _courseRepository.DeleteCourse(id) ?
                Ok() : this.StatusCode(500);
        }
    }
}
