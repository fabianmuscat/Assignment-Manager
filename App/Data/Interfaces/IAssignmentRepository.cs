using Domain.Models;
using Type = Domain.Models.Type;

namespace Data.Interfaces;

public interface IAssignmentRepository
{
    public IQueryable<Assignment> GetAssignments();
    public IQueryable<Type> GetTypes();

    public IQueryable<Module> GetModules();
}