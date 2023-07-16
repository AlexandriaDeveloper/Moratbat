
using System.Reflection;
using System.Security.Claims;
using Domain;
using Domain.IdentityModels;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
#nullable enable
public class AppDataContext : IdentityDbContext<AppUser>
{
    public DbSet<EmployeeModel> Employees { get; set; }
    //  public DbSet<EmployeeBankAccountModel> EmployeeBankAccounts { get; set; }

    public DbSet<AccountTreeModel> AccountsTreeModel { get; set; }
    public DbSet<BankModel> Banks { get; set; }
    public DbSet<GradeModel>? Grades { get; set; }
    public DbSet<CollectionModel>? Collection { get; set; }


    //public DbSet<AppUser> Users { get; set; }
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseExceptionProcessor();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        var authUser = new AppUser() { Id = "12990fe8-1ad9-4e30-a80e-5e664a831480" };
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<BankModel>().HasData(Seed.DataInfo.BanksData(authUser));
        builder.Entity<BankBranchModel>().HasData(Seed.DataInfo.BankBranchData(authUser));
        builder.Entity<GradeModel>().HasData(Seed.DataInfo.GradeData(authUser));

        builder.Entity<DepartmentModel>().HasData(Seed.DataInfo.DepartmentData(authUser));
        builder.Entity<AccountTreeModel>().HasData(Seed.DataInfo.AccountTreeModels(authUser));
        builder.Entity<AccountTreeDetailsModel>().HasData(Seed.DataInfo.AccountTreeDataModels(authUser));
        builder.Entity<CollectionModel>().HasData(Seed.DataInfo.CollectionModelData(authUser));
        base.OnModelCreating(builder);
    }


}

