using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TypeId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Assignment Type cannot have more than 20 characters")]
        public string? AssignmentType { get; set; } = null!;
    }
}