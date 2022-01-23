using Data.Interfaces;
using Domain.Models;
using Type = Domain.Models.Type;

namespace Data.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly AssignmentsContext _context;

    public AssignmentRepository(AssignmentsContext context)
    {
        _context = context;
    }

    public IQueryable<Assignment>? GetAssignments() => _context.Assignments;
    public IQueryable<Type>? GetTypes() => _context.Type;

    public IQueryable<Module>? GetModules() => _context.Modules;
}