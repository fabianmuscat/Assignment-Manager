using Application.ViewModels;

namespace Application.Interfaces;

public interface ICourseService
{
    public void AddCourse(AddCourseViewModel course);
}