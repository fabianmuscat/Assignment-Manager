using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

// Resharper Disable All
public class StudentAssignment
{
    [Required] [ForeignKey("Student")] public string StudentId { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    [Required] [ForeignKey("Assignment")] public int AssignmentID { get; set; }

    public virtual Assignment Assignment { get; set; } = null!;

    [Required] public float Points { get; set; }
}