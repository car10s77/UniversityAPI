using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        Student CreateStudent(Student student);
        Student UpdateStudent(int studentID, Student student);
        bool DeleteStudent(int studentID);
        List<Student> GetStudentsByCourse(int courseId);

    }
}
