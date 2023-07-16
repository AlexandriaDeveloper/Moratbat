using Microsoft.AspNetCore.Identity;
using Persistence.Constants;
namespace Persistence
{
    public partial class Seed
    {
        public static async Task SeedData(AppDataContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var roles = Enum.GetNames(typeof(RolesList));
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>{
                    new AppUser{
                        Id="12990fe8-1ad9-4e30-a80e-5e664a831480",
                        DisplayName="محمد على شريف",
                        UserName="seagaull",
                        Email="seaagull@hotmail.com",
                    },
                        new AppUser{
                        DisplayName="محمود شاهين",
                        UserName="seagaull2",
                        Email="seaagull2@hotmail.com",
                    },
                        new AppUser{
                        DisplayName="طارق جلال",
                        UserName="seagaull3",
                        Email="seaagull3@hotmail.com",
                    }
                };
                foreach (var user in users)
                {
                    var result = await userManager.CreateAsync(user, "fr33tim3#");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, RolesList.Admin.ToString());
                    }
                }
            }
        }
        public static async Task SeedDataToTable(AppDataContext context, ModelBuilder builder)
        {
            var authUser = await context.Users.FirstOrDefaultAsync(x => x.UserName == "seagaull");
            builder.Entity<BankModel>().HasData(DataInfo.BanksData(authUser!));
        }

    }


}