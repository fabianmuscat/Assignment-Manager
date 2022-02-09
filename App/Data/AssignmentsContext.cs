using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Domain.Models.Type;

namespace Data;

// Resharper Disable All
public class AssignmentsContext : IdentityDbContext
{
    public AssignmentsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Grades>? Grades { get; set; }
    public DbSet<Type>? Type { get; set; }
    public DbSet<Course>? Courses { get; set; }
    public DbSet<Module>? Modules { get; set; }
    public DbSet<Student>? Students { get; set; }
    public DbSet<Assignment>? Assignments { get; set; }
    public DbSet<StudentAssignment>? StudentAssignments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many-to-Many Relationship (Student - Assignment)
        modelBuilder
            .Entity<StudentAssignment>()
            .HasKey(sa => new { sa.StudentId, sa.AssignmentID });

        modelBuilder.Entity<StudentAssignment>()
            .HasOne(sa => sa.Student)
            .WithMany(s => s.StudentAssignments)
            .HasForeignKey(sa => sa.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<StudentAssignment>()
            .HasOne(sa => sa.Assignment)
            .WithMany(a => a.StudentAssignments)
            .HasForeignKey(sa => sa.AssignmentID)
            .OnDelete(DeleteBehavior.NoAction);

        // Many-to-Many Relationship (Student - Course)
        modelBuilder
            .Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });

        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentId)
            .OnDelete(DeleteBehavior.NoAction);
        ;

        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseId)
            .OnDelete(DeleteBehavior.NoAction);
        ;

        // modelBuilder.Entity<StudentGrade>().HasNoKey();
        //
        // modelBuilder
        //     .HasDbFunction(typeof(IAssignmentRepository).GetMethod(nameof(IAssignmentRepository.GetCourseId),
        //         new[] { typeof(string) }) ?? throw new InvalidOperationException());
        //
        // modelBuilder
        //     .HasDbFunction(typeof(IAssignmentRepository).GetMethod(nameof(IAssignmentRepository.GetModuleId),
        //         new[] { typeof(string) }) ?? throw new InvalidOperationException());
        //
        // modelBuilder
        //     .HasDbFunction(typeof(IAssignmentRepository).GetMethod(nameof(IAssignmentRepository.GetTypeId),
        //         new[] { typeof(string) }) ?? throw new InvalidOperationException());
        //
        // modelBuilder
        //     .HasDbFunction(typeof(IAssignmentRepository).GetMethod(nameof(IAssignmentRepository.GetModuleTotal),
        //         new[] { typeof(int) }) ?? throw new InvalidOperationException());
        //
        // modelBuilder
        //     .HasDbFunction(typeof(IAssignmentRepository).GetMethod(nameof(IAssignmentRepository.GetStudentGrades),
        //         new[] { typeof(string) }) ?? throw new InvalidOperationException());

        base.OnModelCreating(modelBuilder);
    }
}