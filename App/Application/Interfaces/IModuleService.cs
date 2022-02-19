using System.Linq;
using Application.ViewModels;
// Resharper Disable All

namespace Application.Interfaces
{
    public interface IModuleService
    {
        public IQueryable<AddModuleViewModel> AddModule();
    }   
}