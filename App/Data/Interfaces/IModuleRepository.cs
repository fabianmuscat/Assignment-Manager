using Domain.Models;
using Type = Domain.Models.Type;

namespace Data.Interfaces;

public interface IModuleRepository
{
    public void AddModule(string module, string course, int semesterNumber, int year);
}