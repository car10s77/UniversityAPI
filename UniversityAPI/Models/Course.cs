using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityAPI.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}