using Application.Interfaces;
using Application.ViewModels;
using Data.Interfaces;

namespace Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public IQueryable<AddCourseViewModel> AddCourse()
    {
        throw new NotImplementedException();
    }
}