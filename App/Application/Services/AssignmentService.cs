using Application.Interfaces;
using Application.ViewModels;
using Data.Interfaces;
using Domain.Models;

namespace Application.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IAssignmentRepository _assignmentRepository;

    public AssignmentService(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    public IQueryable<AssignmentViewModel> GetAssignments()
    {
        return _assignmentRepository.GetAssignments()
            .OrderBy(assignment => assignment.DeadlineDate)
            .Select(assignment => new AssignmentViewModel
            {
                Name = assignment.AssignmentName,
                ModuleName = _assignmentRepository.GetModules().FirstOrDefault(m => m.ModuleId == assignment.ModuleId) != null ? 
                    _assignmentRepository.GetModules().FirstOrDefault(m => m.ModuleId == assignment.ModuleId)!.ModuleName : "",
                StartDate = assignment.DateIssued,
                DeadlineDate = assignment.DeadlineDate,
                Grade = "A",
                Marks = 21,
                MaxMark = assignment.MaxMark,
                Type = (_assignmentRepository.GetTypes().FirstOrDefault(a => a.TypeId == assignment.TypeId) != null ? 
                    _assignmentRepository.GetTypes().FirstOrDefault(a => a.TypeId == assignment.TypeId)!.AssignmentType : "")!
            });
    }
}