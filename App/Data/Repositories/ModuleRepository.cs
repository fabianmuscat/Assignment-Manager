using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ModuleRepository : IModuleRepository
{
    private readonly AssignmentsContext _context;

    public ModuleRepository(AssignmentsContext context)
    {
        _context = context;
    }
    
    public void AddModule(string module, string course, int semesterNumber, int year)
    {
        _context.Modules!.FromSqlRaw($"EXEC AddModule {module} {course} {semesterNumber} {year}");
    }
}