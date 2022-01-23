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
        
        base.OnModelCreating(modelBuilder);
    }
}