using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int courseId);
        Course CreateCourse(Course course);
        Course UpdateCourse(int courseId, Course course);
        bool DeleteCourse(int courseId);
    }
}
