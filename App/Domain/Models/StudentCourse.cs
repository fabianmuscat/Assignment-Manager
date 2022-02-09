using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

// Resharper Disable All
public class StudentCourse
{
    [Key]
    [Required] [ForeignKey("Student")] public string StudentId { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    [Key]
    [Required] [ForeignKey("Course")] public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;
}