using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;
// Resharper Disable All

public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CourseID { get; set; }

    [Required] 
    [StringLength(50)] 
    public string CourseName { get; set; } = null!;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime EnrollmentDate { get; set; }

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime EndDate { get; set; }

    public virtual ICollection<Module> Modules { get; set; } = null!;
    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = null!;
}