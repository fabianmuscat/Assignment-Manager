using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;
// ReSharper disable once CollectionNeverUpdated.Global
// ReSharper disable once VirtualMemberCallInConstructor
// ReSharper disable once ClassNeverInstantiated.Global

public class Assignment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AssignmentID { get; set; }

    [Required] public string? AssignmentName { get; set; }

    [Required] [ForeignKey("Module")] public int ModuleId { get; set; }

    [Required] public byte MaxMark { get; set; }
    
    [Required] public int Semester { get; set; }

    [Required] public DateTime DateIssued { get; set; }

    [Required] public DateTime DeadlineDate { get; set; }

    [Required] [ForeignKey("Type")] public int TypeId { get; set; }

    public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }

    private Assignment()
    {
        StudentAssignments = new List<StudentAssignment>();
    }
}