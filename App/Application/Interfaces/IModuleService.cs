using Application.ViewModels;

namespace Application.Interfaces;

public interface IModuleService
{
    public IQueryable<AddModuleViewModel> AddModule();
}