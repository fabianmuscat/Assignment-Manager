using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;
// Resharper Disable All
// ReSharper disable once VirtualMemberCallInConstructor

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [StringLength(8, ErrorMessage = "ID Card must be exactly 8 characters")]
    public string? StudentID { get; set; }

    [Required] public string? FirstName { get; set; }

    [Required] public string? LastName { get; set; }

    [Required] public string? SchoolEmail { get; set; }

    [ForeignKey("Course")] public int CourseID { get; set; }

    public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }

    protected Student()
    {
        StudentAssignments = new List<StudentAssignment>();
    }
}