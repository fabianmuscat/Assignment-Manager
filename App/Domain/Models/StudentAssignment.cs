using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
// Resharper Disable All

public class StudentAssignment
{
    public string StudentID { get; set; } = null!;
    public virtual Student? Student { get; set; }

    public int AssignmentID { get; set; }
    public virtual Assignment? Assignment { get; set; }

    [Required] public float Points { get; set; }
}