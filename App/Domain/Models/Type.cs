using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;
// Resharper Disable All

public class Type
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TypeId { get; set; }

    [Required]
    public string AssignmentType { get; set; } = null!;

    public virtual ICollection<Assignment> Assignments { get; set; } = null!;
}