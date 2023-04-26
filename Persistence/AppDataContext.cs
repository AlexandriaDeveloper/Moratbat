
using System.Reflection;
using Domain;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class AppDataContext : IdentityDbContext<AppUser>
{
    public DbSet<EmployeeModel> Employees { get; set; }
    public DbSet<BankModel> Banks { get; set; }
    public DbSet<GradeModel> Grades { get; set; }

    public DbSet<AppUser> Users { get; set; }
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }
    protected override async void OnModelCreating(ModelBuilder builder)
    {
        //HardCoded Till I figure better way
        var authUser = new AppUser() { Id = "ea158a09-f87b-4736-9e50-f0516c8ece15" };
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<BankModel>().HasData(Seed.DataInfo.BanksData(authUser));
        builder.Entity<GradeModel>().HasData(Seed.DataInfo.GradeData(authUser));
        builder.Entity<DepartmentModel>().HasData(Seed.DataInfo.DepartmentData(authUser));
        base.OnModelCreating(builder);



    }


}

