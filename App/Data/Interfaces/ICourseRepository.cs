namespace Data.Interfaces;

public interface ICourseRepository
{
    public void AddCourse(string name, DateTime enrollmentDate, DateTime endDate);
}