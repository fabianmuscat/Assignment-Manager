// Resharper Disable All

namespace Data.Interfaces
{
    public interface IModuleRepository
    {
        public void AddModule(string module, string course, int semesterNumber, int year);
    }    
}