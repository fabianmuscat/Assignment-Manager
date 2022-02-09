using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels;

public class AddAssignmentViewModel
{
    [Required(AllowEmptyStrings = true, ErrorMessage = "Assignment Title cannot be empty")]
    public string? Name { get; set; }


    [Required(AllowEmptyStrings = true, ErrorMessage = "Module Name cannot be empty")]
    public string? ModuleName { get; set; }

    [Required] public string? AssignmentDates { get; set; }

    [Required]
    [Range(0, 100, ErrorMessage = "Mark must be between 0 and 100")]
    public int MaxMark { get; set; }


    [Required]
    [Range(1, 2, ErrorMessage = "Semester number must be either 1 or 2")]
    public int SemesterNumber { get; set; }


    [Required(ErrorMessage = "Type cannot be empty")]
    public string? Type { get; set; }
}