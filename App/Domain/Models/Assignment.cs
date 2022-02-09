using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

// ReSharper disable all
public class Assignment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AssignmentID { get; set; }

    [Required] public string AssignmentName { get; set; } = null!;

    [Required] [ForeignKey("Module")] public int ModuleId { get; set; }

    [Required] public byte MaxMark { get; set; }

    [Required] public int Semester { get; set; }

    [Required] public DateTime DateIssued { get; set; }

    [Required] public DateTime DeadlineDate { get; set; }

    [Required] [ForeignKey("Type")] public int TypeId { get; set; }

    public virtual Type Type { get; set; } = null!;

    [Required] [ForeignKey("Student")] public string StudentId { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual ICollection<StudentAssignment> StudentAssignments { get; set; } = null!;
}