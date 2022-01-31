using Application.Interfaces;
using Application.ViewModels;
using Data.Interfaces;

namespace Application.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;

    public ModuleService(IModuleRepository moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

    public IQueryable<AddModuleViewModel> AddModule()
    {
        throw new NotImplementedException();
    }
}