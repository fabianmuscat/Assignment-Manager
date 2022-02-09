using Application.ViewModels;

namespace Application.Interfaces;

public interface ICourseService
{
    public string AddCourse(AddCourseViewModel course);
    public Dictionary<CourseViewModel, int> GetCourses(string user);
}