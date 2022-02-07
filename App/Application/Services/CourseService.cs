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

    public void AddCourse(AddCourseViewModel course)
    {
        var name = course.Name!.Trim();
        var sEnrollmentDate = course.EnrollmentDates!.Split("-")[0];
        var sEndDate = course.EnrollmentDates!.Split("-")[1];

        DateTime.TryParse(sEnrollmentDate, out var enrollmentDate);
        DateTime.TryParse(sEndDate, out var endDate);
        
        _courseRepository.AddCourse(name, enrollmentDate, endDate);
    }
}