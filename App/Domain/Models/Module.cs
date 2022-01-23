using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ModuleID { get; set; } = null!;

        [Required] [StringLength(50)] public string ModuleName { get; set; } = null!;

        [Required] public byte SemesterNumber { get; set; }

        [Required] [ForeignKey("Course")] public Guid CourseID { get; set; }
    }
}