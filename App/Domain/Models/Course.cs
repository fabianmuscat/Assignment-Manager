using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;
// Resharper Disable All

public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CourseID { get; set; }

    [Required] [StringLength(50)] public string CourseName { get; set; } = null!;

    [Required] public int EnrollmentYear { get; set; }

    [Required] public int FinalYear { get; set; }
}