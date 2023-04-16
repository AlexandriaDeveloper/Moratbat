using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class AppDataContext : IdentityDbContext<AppUser>
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new IAppUserConfiguration());
        base.OnModelCreating(builder);
    }

}
