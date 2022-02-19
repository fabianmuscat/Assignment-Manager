using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// Resharper Disable All

namespace Domain.Models
{
    public class StudentAssignment
    {
        [Key]
        [Required] [ForeignKey("Student")] public string StudentId { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;

        [Key]
        [Required] [ForeignKey("Assignment")] public int AssignmentID { get; set; }

        public virtual Assignment Assignment { get; set; } = null!;

        [Required] public float Points { get; set; }
    }
}

