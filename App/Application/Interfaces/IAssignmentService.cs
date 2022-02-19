using System.Linq;
using Application.ViewModels;
// Resharper Disable All

namespace Application.Interfaces
{
    public interface IAssignmentService
    {
        public IQueryable<AssignmentViewModel> GetAssignments();
    }   
}