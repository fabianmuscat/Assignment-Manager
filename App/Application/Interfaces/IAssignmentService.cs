using Application.ViewModels;

namespace Application.Interfaces;

public interface IAssignmentService
{
    public IQueryable<AssignmentViewModel> GetAssignments();
}