using UniversityAPI.Data;
using UniversityAPI.Models;

namespace UniversityAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) { _context = context; }

        public Student CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public bool DeleteStudent(int studentID)
        {
            var _student = _context.Students.FirstOrDefault(s => s.Id == studentID);
            if (_student != null)
            {
                _context.Remove(_student);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(student => student.Id == id);
        }

        public Student UpdateStudent(int studentID, Student student)
        {
            var _student = _context.Students.FirstOrDefault(s =>s.Id == studentID);
            if (_student != null)
            {
                _student.Name = student.Name;
                _student.CourseId = student.CourseId;
                _context.SaveChanges();
            }

            return _student;
        }

        public List<Student> GetStudentsByCourse(int courseId)
        {
            var students = _context.Students
                .Where(s => s.CourseId == courseId)
                .ToList();

            return students;
        }
    }
}
