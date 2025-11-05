using MediatR;
using TaskManagementApp.Infrastructure.Mapping;
using TaskManagementApp.Infrastructure;
using TaskManagementApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TaskManagementApp.Application.AssemblyReference).Assembly));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register infrastructure services (EF Core InMemory database)
builder.Services.AddInfrastructure();

var app = builder.Build();

// Seed the database with sample data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DataSeeder.SeedData(context);
}

// Configure the HTTP request pipeline.
app.UseCors();
app.UseStaticFiles();
app.UseRouting();

// Serve index.html as default
app.UseDefaultFiles();

app.MapControllers();

app.Run();
