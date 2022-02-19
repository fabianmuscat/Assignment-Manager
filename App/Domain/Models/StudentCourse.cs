using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// Resharper Disable All

namespace Domain.Models
{
    public class StudentCourse
    {
        [Key]
        [Required] [ForeignKey("Student")] public string StudentId { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;

        [Key]
        [Required] [ForeignKey("Course")] public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}