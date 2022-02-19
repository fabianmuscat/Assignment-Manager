using System.ComponentModel.DataAnnotations;
// Resharper Disable All

namespace Domain.Models
{
    public class Grades
    {
        [Key]
        [StringLength(2, ErrorMessage = "Grade must not have more than 2 characters")]
        public string Grade { get; set; } = null!;

        public byte MinimumMark { get; set; }
        public byte MaximumMark { get; set; }
    }
}

