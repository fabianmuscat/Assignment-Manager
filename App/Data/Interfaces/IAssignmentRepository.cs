using Domain.Models;
using Type = Domain.Models.Type;

namespace Data.Interfaces;

public interface IAssignmentRepository
{
    public IQueryable<Assignment>? GetAssignments();
    public IQueryable<Type>? GetTypes();

    public IQueryable<Module>? GetModules();

    public void AddAssignment(string name, string module, string type, int semester, int maxMark, DateTime startDate, DateTime deadlineDate);

    // public static int GetCourseId(string course) => throw new NotSupportedException();
    // public static int GetModuleId(string module) => throw new NotSupportedException();
    // public static int GetTypeId(string type) => throw new NotSupportedException();
    // public static int GetModuleTotal(int moduleId) => throw new NotSupportedException();
    // public static IQueryable<StudentGrade> GetStudentGrades(string course) => throw new NotSupportedException();
}