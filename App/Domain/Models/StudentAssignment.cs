using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class StudentAssignment
    {
        public string StudentID { get; set; } = null!;
        public virtual Student? Student { get; set; }

        public Guid AssignmentID { get; set; }
        public virtual Assignment? Assignment { get; set; }

        [Required] public byte Points { get; set; }
    }
}