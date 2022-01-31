using Data.Interfaces;

namespace Data.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AssignmentsContext _context;

    public CourseRepository(AssignmentsContext context)
    {
        _context = context;
    }

    public void AddCourse(string name, int enrollmentYear, int finalYear)
    {
        throw new NotImplementedException();
    }
}