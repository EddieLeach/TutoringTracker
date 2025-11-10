using Microsoft.EntityFrameworkCore;
using TutoringTracker.Models;

namespace TutoringTracker.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Visit> Visits => Set<Visit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed sample students
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, StudentId = "S1001", Name = "Alex Rivera" },
            new Student { Id = 2, StudentId = "S1002", Name = "Jordan Lee" },
            new Student { Id = 3, StudentId = "S1003", Name = "Morgan Patel" }
        );

        // Seed math courses
        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Code = "MATH-0305", Title = "Developmental Mathematics Lab" },
            new Course { Id = 2, Code = "MATH-1314", Title = "College Algebra" },
            new Course { Id = 3, Code = "MATH-1342", Title = "Elementary Statistics" },
            new Course { Id = 4, Code = "MATH-2412", Title = "Precalculus" },
            new Course { Id = 5, Code = "MATH-2413", Title = "Calculus I" }
        );
    }
}
