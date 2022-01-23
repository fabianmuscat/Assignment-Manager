using Data.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Domain.Models.Type;

namespace Data;
// Resharper Disable All

public class AssignmentsContext : IdentityDbContext
{
    public DbSet<Grades>? Grades { get; set; }
    public DbSet<Type>? Type { get; set; }
    public DbSet<Course>? Courses { get; set; }
    public DbSet<Module>? Modules { get; set; }
    public DbSet<Student>? Students { get; set; }
    public DbSet<Assignment>? Assignments { get; set; }
    public DbSet<StudentAssignment>? StudentAssignments { get; set; }
    
    public AssignmentsContext(DbContextOptions options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<StudentAssignment>()
            .HasKey(sa => new {sa.StudentID, sa.AssignmentID});
        
        modelBuilder.Entity<StudentAssignment>()
            .HasOne(sa => sa.Student)
            .WithMany(s => s.StudentAssignments)
            .HasForeignKey(sa => sa.StudentID);
        
        modelBuilder.Entity<StudentAssignment>()
            .HasOne(sa => sa.Assignment)
            .WithMany(a => a.StudentAssignments)
            .HasForeignKey(sa => sa.AssignmentID);

        modelBuilder.Entity<StudentGrade>().HasNoKey();

        modelBuilder
            .HasDbFunction(typeof(IAssignmentRepository).GetMethod(nameof(IAssignmentRepository.GetCourseId),
                new[] { typeof(string) }) ?? throw new InvalidOperationException());
        
        modelBuilder
            .HasDbFunction(typeof(IAssignmentRepository).GetMethod(nameof(IAssignmentRepository.GetModuleId),
                new[] { typeof(string) }) ?? throw new InvalidOperationException());
        
        modelBuilder
            .HasDbFunction(typeof(IAssignmentRepository).GetMethod(nameof(IAssignmentRepository.GetTypeId),
                new[] { typeof(string) }) ?? throw new InvalidOperationException());
        
        modelBuilder
            .HasDbFunction(typeof(IAssignmentRepository).GetMethod(nameof(IAssignmentRepository.GetModuleTotal),
                new[] { typeof(int) }) ?? throw new InvalidOperationException());
        
        modelBuilder
            .HasDbFunction(typeof(IAssignmentRepository).GetMethod(nameof(IAssignmentRepository.GetStudentGrades),
                new[] { typeof(string) }) ?? throw new InvalidOperationException());
        
        base.OnModelCreating(modelBuilder);
    }
}