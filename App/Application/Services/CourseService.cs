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

    public string AddCourse(AddCourseViewModel course)
    {
        var name = course.Name!.Trim();
        var sEnrollmentDate = course.EnrollmentDates!.Split("-")[0];
        var sEndDate = course.EnrollmentDates!.Split("-")[1];

        DateTime.TryParse(sEnrollmentDate, out var enrollmentDate);
        DateTime.TryParse(sEndDate, out var endDate);
        
        if (DateTime.Compare(enrollmentDate, endDate) > 0)
            return "End Date cannot be before the enrollment date";

        _courseRepository.AddCourse(name, enrollmentDate, endDate, course.User!);
        return string.Empty;
    }
    
    public Dictionary<CourseViewModel, int> GetCourses(string user)
    {
        var dictionary = new Dictionary<CourseViewModel, int>();
        _courseRepository.GetCourses(user).ToList().ForEach(course =>
        {
            var years = _courseRepository.GetYearsForCourse(course.CourseName);
            dictionary.Add(new CourseViewModel
            {
                CourseName = course.CourseName,
                EnrollmentDate = course.EnrollmentDate,
                EndDate = course.EndDate
            }, years);
        });

        return dictionary;
    }
}