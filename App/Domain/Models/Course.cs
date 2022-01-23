using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CourseID { get; set; }

        [Required] [StringLength(50)] public string CourseName { get; set; } = null!;

        [Required] public int EnrollmentYear { get; set; }

        [Required] public int FinalYear { get; set; }
    }
}