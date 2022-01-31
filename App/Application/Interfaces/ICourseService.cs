using Application.ViewModels;

namespace Application.Interfaces;

public interface ICourseService
{
    public IQueryable<AddCourseViewModel> AddCourse();
}