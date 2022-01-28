using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ViewModels;

public class AddModule
{
    [Required(ErrorMessage = "Module Name cannot be empty")]
    public string? Name { get; set; }
    
    [Required]
    [Range(1, 2, ErrorMessage = "Semester number must be either 1 or 2")]
    public int SemesterNumber { get; set; }

    [Required(ErrorMessage = "Year cannot be empty")]
    public int Year { get; set; }
}