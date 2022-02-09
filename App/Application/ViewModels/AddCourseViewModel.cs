using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels;

public class AddCourseViewModel
{
    [Required(AllowEmptyStrings = true, ErrorMessage = "Course Name cannot be empty")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Enrollment Year cannot be empty")]
    public string? EnrollmentDates { get; set; }
    
    [Required] 
    public string? User { get; set; }
}