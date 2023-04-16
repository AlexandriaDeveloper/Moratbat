
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Extensions;
using API.Extensions;
using Microsoft.AspNetCore.Identity;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);

builder.Services.AddControllers(opt =>
{
    //this will take care to authorize all controlers

    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var provider = builder.Services.BuildServiceProvider();
try
{


    var context = provider.GetRequiredService<AppDataContext>();
    await context.Database.MigrateAsync();
    var userManagaer = provider.GetRequiredService<UserManager<AppUser>>();
    var roleManagaer = provider.GetRequiredService<RoleManager<IdentityRole>>();
    await Seed.SeedData(context, userManagaer, roleManagaer);
}
catch (Exception ex)
{

    var logger = provider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An Error Occured During Migration");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
