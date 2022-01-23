using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Student
    {
        public Student()
        {
            StudentAssignments = new List<StudentAssignment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(8, ErrorMessage = "ID Card must be exactly 8 characters")]
        public string StudentID { get; set; } = null!;

        [Required] public string FirstName { get; set; } = null!;

        [Required] public string LastName { get; set; } = null!;

        [Required] public string SchoolEmail { get; set; } = null!;

        [ForeignKey("Course")] public Guid CourseID { get; set; }

        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}