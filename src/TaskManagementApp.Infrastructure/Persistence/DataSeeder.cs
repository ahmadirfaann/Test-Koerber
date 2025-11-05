using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Infrastructure.Persistence;

public static class DataSeeder
{
    public static void SeedData(ApplicationDbContext context)
    {
        if (context.Tasks.Any())
        {
            return; // Database already seeded
        }

        var tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Title = "Complete project documentation",
                Description = "Write comprehensive documentation for the Task Management API including setup instructions and API endpoints",
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new TaskItem
            {
                Title = "Review pull requests",
                Description = "Review and merge pending pull requests from team members",
                IsCompleted = true,
                CreatedAt = DateTime.UtcNow.AddDays(-4),
                CompletedAt = DateTime.UtcNow.AddDays(-3)
            },
            new TaskItem
            {
                Title = "Update dependencies",
                Description = "Update all NuGet packages to their latest stable versions",
                IsCompleted = true,
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                CompletedAt = DateTime.UtcNow.AddDays(-2)
            },
            new TaskItem
            {
                Title = "Implement user authentication",
                Description = "Add JWT-based authentication to the API endpoints",
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow.AddDays(-2)
            },
            new TaskItem
            {
                Title = "Design database schema",
                Description = "Create ER diagrams and finalize database table structures",
                IsCompleted = true,
                CreatedAt = DateTime.UtcNow.AddDays(-6),
                CompletedAt = DateTime.UtcNow.AddDays(-5)
            },
            new TaskItem
            {
                Title = "Conduct code review session",
                Description = "Schedule and conduct weekly code review session with the development team",
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new TaskItem
            {
                Title = "Fix responsive layout issues",
                Description = "Resolve mobile and tablet layout issues in the task list view",
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            },
            new TaskItem
            {
                Title = "Prepare for deployment",
                Description = "Set up CI/CD pipeline and prepare production environment",
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            }
        };

        context.Tasks.AddRange(tasks);
        context.SaveChanges();
    }
}
