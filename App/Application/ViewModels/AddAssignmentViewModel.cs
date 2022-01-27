using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

namespace Application.ViewModels;

public class AddAssignmentViewModel
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
    [Range(1, 2, ErrorMessage = "Valid semesters are 1 and 2")]
    public int SemesterNumber { get; set; }
    
    [Required] public string Type { get; set; }
}