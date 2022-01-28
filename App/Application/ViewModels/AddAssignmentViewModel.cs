using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels;

public class AddAssignment
{
    [Required(ErrorMessage = "Assignment Title cannot be empty")] 
    public string? Name { get; set; }
    [Required] public string? ModuleName { get; set; }
    
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime DeadlineDate { get; set; }
    
    [Required]
    [Range(0, 100, ErrorMessage = "Mark must be between 0 and 100")]
    public int MaxMark { get; set; }
    
    [Required] 
    [Range(1, 2, ErrorMessage = "Semester number must be either 1 or 2")]
    public int SemesterNumber { get; set; }
    
    [Required] public string Type { get; set; }
}