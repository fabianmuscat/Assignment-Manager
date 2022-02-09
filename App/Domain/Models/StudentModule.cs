using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

// Resharper Disable All
public class StudentModule
{
    [Key]
    [Required] [ForeignKey("Student")] public string StudentId { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    [Key]
    [Required] [ForeignKey("Module")] public int ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;
}