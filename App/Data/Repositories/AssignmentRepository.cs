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

    public IQueryable<Assignment> GetAssignments()
    {
        return _context.Assignments;
    }

    public IQueryable<Type> GetTypes()
    {
        return _context.Type;
    }

    public IQueryable<Module> GetModules()
    {
        return _context.Modules;
    }

    public void AddAssignment(string name, string module, string type, int semester, int maxMark, DateTime startDate,
        DateTime deadlineDate)
    {
        _context.Assignments!.FromSqlRaw(
            $"EXEC AddAssignment {name} {module} {type} {semester} {maxMark} {startDate} {deadlineDate}");
    }
}