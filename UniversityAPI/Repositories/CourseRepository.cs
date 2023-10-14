using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniversityAPI.Data;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public Course CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public bool DeleteCourse(int courseId)
        {
            var course = _context.Courses.FirstOrDefault(course => course.Id == courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses.Include(c=> c.Students).ToList();
        }

        public Course GetCourseById(int courseId)
        {
            return _context.Courses.Include(c=> c.Students).FirstOrDefault(c => c.Id == courseId);
        }

        public Course UpdateCourse(int courseId ,Course course)
        {
            var _course = _context.Courses.FirstOrDefault(c => c.Id == courseId);
            if (_course != null)
            {
                _course.Title = course.Title;
                _context.SaveChanges();
            }

            return course;
        }
    }
}
