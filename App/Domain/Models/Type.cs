using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// Resharper Disable All

namespace Domain.Models
{
    public class Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        [Required] public string AssignmentType { get; set; } = null!;

        public virtual ICollection<Assignment> Assignments { get; set; } = null!;
    }
}

