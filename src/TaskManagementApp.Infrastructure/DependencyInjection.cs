using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementApp.Application.Common.Interfaces;
using TaskManagementApp.Infrastructure.Persistence;
using TaskManagementApp.Infrastructure.Repositories;

namespace TaskManagementApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("TaskManagementDb"));

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
}
