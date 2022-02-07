using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AssignmentsContext _context;

    public CourseRepository(AssignmentsContext context)
    {
        _context = context;
    }

    public void AddCourse(string name, DateTime enrollmentDate, DateTime finalDate)
    {
        _context.Courses!.FromSqlRaw($"EXEC AddCourse {name} {enrollmentDate} {finalDate}");
    }
}