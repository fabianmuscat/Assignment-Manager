using Domain.Models;

namespace Data.Interfaces;

public interface ICourseRepository
{
    public IQueryable<Course> GetCourses(string user);
    public int GetYearsForCourse(string course);
    
    public string AddCourse(string name, DateTime enrollmentDate, DateTime endDate, string userEmail);
    public Student GetStudentId(string email);
}