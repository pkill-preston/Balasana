using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace Balasana.Infrastructure.Persistence.Configurations;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}