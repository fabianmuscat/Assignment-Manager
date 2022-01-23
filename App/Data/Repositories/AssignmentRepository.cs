using Data.Interfaces;
using Domain.Models;
using Type = Domain.Models.Type;

namespace Data.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly AssignmentsContext _context;
    private IQueryable<Module> _getModules;

    public AssignmentRepository(AssignmentsContext context)
    {
        _context = context;
    }

    public IQueryable<Assignment> GetAssignments() => _context.Assignment;
    public IQueryable<Type> GetTypes() => _context.Type;

    public IQueryable<Module> GetModules() => _context.Module;
}