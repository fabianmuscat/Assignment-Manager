using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

// Resharper Disable All
public class Student : IdentityUser
{
    [StringLength(8, ErrorMessage = "ID Card must be exactly 8 characters")]
    public string? IDCard { get; set; }

    [Required] public string FirstName { get; set; } = null!;

    [Required] public string LastName { get; set; } = null!;

    public virtual ICollection<Assignment> Assignments { get; set; } = null!;
    public virtual ICollection<Module> Modules { get; set; } = null!;
    public virtual ICollection<StudentAssignment> StudentAssignments { get; set; } = null!;
    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = null!;
    public virtual ICollection<StudentModule> StudentModules { get; set; } = null!;
}