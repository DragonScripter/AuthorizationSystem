using Authentication.Data;
using Authentication.Model;
using Authentication.Service.Implementation;
using Authentication.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Text;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IUserService, UserService>(); // AddScoped needs a generic syntax
    services.AddScoped<IRoleService, RoleService>(); // Same here
}

ConfigureServices(builder.Services);

static async Task Seeding(IServiceProvider service) 
{
    using (var scope = service.CreateScope()) 
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        var seeder = new SeedingAuthority(roleManager, userManager);
        await seeder.SeedingAsync();
    }
} 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); 
app.UseStaticFiles();

app.MapControllers();

app.Run();
