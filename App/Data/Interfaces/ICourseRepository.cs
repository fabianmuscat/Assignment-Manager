namespace Data.Interfaces;

public interface ICourseRepository
{
    public void AddCourse(string name, int enrollmentYear, int finalYear);
}