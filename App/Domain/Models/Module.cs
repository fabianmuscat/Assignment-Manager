using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

// Resharper Disable All
public class Module
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ModuleId { get; set; }

    [Required] [StringLength(255)] public string ModuleName { get; set; } = null!;

    [Required] public byte SemesterNumber { get; set; }

    [Required]
    [Column(TypeName = "numeric(4,0)")]
    public int Year { get; set; }

    [Required] [ForeignKey("Course")] public int CourseID { get; set; }

    public virtual Course Course { get; set; } = null!;
    
    public virtual ICollection<StudentModule> StudentModules { get; set; } = null!;
}