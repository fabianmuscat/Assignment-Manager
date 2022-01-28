namespace Application.ViewModels;

public class Assignment
{
    public string? Name { get; set; }
    public string? ModuleName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DeadlineDate { get; set; }
    public int MaxMark { get; set; }
    public int? Marks { get; set; }
    public string? Grade { get; set; }
    public string Type { get; set; }
}