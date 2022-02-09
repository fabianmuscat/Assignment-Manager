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

    public DbSet<Grades> Grades { get; set; } = null!;
    public DbSet<Type> Type { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Module> Modules { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Assignment> Assignments { get; set; } = null!;
    public DbSet<StudentAssignment> StudentAssignments { get; set; } = null!;
    public DbSet<StudentCourse> StudentCourses { get; set; } = null!;

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

        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseId)
            .OnDelete(DeleteBehavior.NoAction);
        
        // Many-to-Many Relationship (Student - Module)
        modelBuilder
            .Entity<StudentModule>()
            .HasKey(sm => new { sm.StudentId, sm.ModuleId });

        modelBuilder.Entity<StudentModule>()
            .HasOne(sm => sm.Student)
            .WithMany(s => s.StudentModules)
            .HasForeignKey(sm => sm.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<StudentModule>()
            .HasOne(sm => sm.Module)
            .WithMany(m => m.StudentModules)
            .HasForeignKey(sm => sm.ModuleId)
            .OnDelete(DeleteBehavior.NoAction);

        // Unique Fields
        modelBuilder.Entity<Course>()
            .HasIndex(c => c.CourseName)
            .IsUnique();
        
        modelBuilder.Entity<Module>()
            .HasIndex(m => m.ModuleName)
            .IsUnique();
        
        modelBuilder.Entity<Assignment>()
            .HasIndex(a => a.AssignmentName)
            .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }
}