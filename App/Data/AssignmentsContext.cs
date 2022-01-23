using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Type = Domain.Models.Type;

namespace Data
{
    public class AssignmentsContext : DbContext
    {
        public DbSet<Grades> Grades { get; set; } = null!;
        public DbSet<Type> Type { get; set; } = null!;
        public DbSet<Course> Course { get; set; } = null!;
        public DbSet<Module> Module { get; set; } = null!;
        public DbSet<Student> Student { get; set; } = null!;
        public DbSet<Assignment> Assignment { get; set; } = null!;
        public DbSet<StudentAssignment> StudentAssignment { get; set; } = null!;

        // public DbSet<DbFunctions.ModuleTotal> ModuleTotalFunction { get; set; } = null!;
        // public DbSet<DbFunctions.ModuleDetails> ModuleDetailsFunction { get; set; } = null!;
        
        public AssignmentsContext(DbContextOptions options) : base(options)
        { }

        public AssignmentsContext()
        { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
            
            // modelBuilder.Entity<DbFunctions.ModuleTotal>(f => f.HasNoKey());
            // modelBuilder.Entity<DbFunctions.ModuleDetails>(f => f.HasNoKey());
        }
    }
}