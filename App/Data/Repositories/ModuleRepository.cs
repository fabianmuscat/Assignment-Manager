using Data.Interfaces;

namespace Data.Repositories;

public class ModuleRepository : IModuleRepository
{
    private readonly AssignmentsContext _context;

    public ModuleRepository(AssignmentsContext context)
    {
        _context = context;
    }
    
    public void AddModule(string module, int semesterNumber, int year)
    {
        throw new NotImplementedException();
    }
}