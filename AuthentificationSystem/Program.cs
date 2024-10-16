using Authentication.Data;
using Authentication.Model;
using Authentication.Service.Implementation;
using Authentication.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Text;
using System.Text;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "Server",
        ValidAudience = "User",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"))),

    };
});

void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IUserService, UserService>(); 
    services.AddScoped<IRoleService, RoleService>();
    builder.Services.AddIdentity<AppUser, RoleEF>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

    services.AddLogging(config =>
    {
        config.AddConsole();
        config.AddDebug();
    });

    //adding the cors for frontend and backend to link
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
    });
    builder.Services.AddControllersWithViews();
}

ConfigureServices(builder.Services);

static async Task Seeding(IServiceProvider service)
{
    using (var scope = service.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<RoleEF>>();
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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await Seeding(services);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
