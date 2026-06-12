using Balasana.Infrastructure.Persistence.Configurations;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load(Path.Combine(Directory.GetCurrentDirectory(), "../../.env"));

var connectionString =
    $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
    $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
    $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
    $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
    $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(connectionString!);

builder.Services.AddDbContext<AppDbContext>(options =>
    {
        Console.WriteLine($"Connecting to database: {connectionString}");
        options.UseNpgsql(connectionString);
    }
);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var canConnect = db.Database.CanConnect();

    Console.WriteLine($"Postgres connection: {canConnect}");
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();