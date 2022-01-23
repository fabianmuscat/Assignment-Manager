using Data.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
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
    
    public void AddAssignment(string name, string module, string type, int maxMark, DateTime startDate, DateTime deadlineDate)
    {
        _context.Assignments!.FromSqlRaw($"AddAssignment {name} {module} {type} {maxMark} {startDate} {deadlineDate}");
    }
}