using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Assignment
    {
        public Assignment()
        {
            StudentAssignments = new List<StudentAssignment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AssignmentID { get; set; }

        [Required] public string AssignmentName { get; set; } = null!;

        [Required] [ForeignKey("Module")] public string ModuleID { get; set; } = null!;

        [Required] public byte MaxMark { get; set; }

        [Required] public DateTime DateIssued { get; set; }

        [Required] public DateTime DeadlineDate { get; set; }

        [Required] [ForeignKey("Type")] public Guid TypeID { get; set; }

        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}