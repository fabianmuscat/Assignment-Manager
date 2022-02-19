using System;
using System.Linq;
using Application.Interfaces;
using Application.ViewModels;
using Data.Interfaces;
// Resharper Disable All

namespace Application.Services
{
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
}