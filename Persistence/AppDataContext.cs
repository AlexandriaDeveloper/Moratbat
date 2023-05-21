
using System.Reflection;
using System.Security.Claims;
using Domain;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
#nullable enable
public class AppDataContext : IdentityDbContext<AppUser>
{
    public DbSet<EmployeeModel> Employees { get; set; }
    public DbSet<BankModel> Banks { get; set; }
    public DbSet<GradeModel>? Grades { get; set; }


    //public DbSet<AppUser> Users { get; set; }
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //HardCoded Till I figure better way
        //  var uuid = _accessor.HttpContext.User.FindFirstValue("UUID");
        var authUser = new AppUser() { Id = "12990fe8-1ad9-4e30-a80e-5e664a831480" };


        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        builder.Entity<BankModel>().HasData(Seed.DataInfo.BanksData(authUser));
        builder.Entity<GradeModel>().HasData(Seed.DataInfo.GradeData(authUser));
        builder.Entity<DepartmentModel>().HasData(Seed.DataInfo.DepartmentData(authUser));
        base.OnModelCreating(builder);



    }


}

