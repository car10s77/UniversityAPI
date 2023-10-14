using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public int? CourseId { get; set; }

        [JsonIgnore]
        public Course? Course { get; set; }
    }
}
