using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MinimalAPI.Validation.Validators;
using MinimalAPI.Data;
using MinimalAPI;
using MinimalAPI.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using dotenv.net;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));
    builder.Services.AddValidatorsFromAssemblyContaining(typeof(NewOrderValidator));

    // Identity
    builder.Services.AddIdentity<User, IdentityRole>(x =>
    {
        // Low password security for demo purposes only
        x.Password.RequireDigit = false;
        x.Password.RequireLowercase = false;
        x.Password.RequireNonAlphanumeric = false;
        x.Password.RequireUppercase = false;
        x.Password.RequiredLength = 3;
        x.User.RequireUniqueEmail = true;
    }).AddEntityFrameworkStores<DataContext>();

    // Add authentication
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT_KEY"]!))
        };
    });

    builder.Services.AddAuthorization();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    Endpoints.Map(app);

    app.Run();
}