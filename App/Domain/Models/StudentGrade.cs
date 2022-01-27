using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;
// ReSharper disable once ClassNeverInstantiated.Global

[NotMapped]
[Keyless]
public class StudentGrade
{
    public string ModuleName { get; set; }
    public string AssignmentName { get; set; }
    public string Grade { get; set; }
}