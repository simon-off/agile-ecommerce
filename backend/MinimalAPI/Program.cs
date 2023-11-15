using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MinimalAPI.Validation.Validators;
using MinimalAPI.Data;
using MinimalAPI;
using MinimalAPI.Extensions;
using dotenv.net;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));
    builder.Services.AddValidatorsFromAssemblyContaining(typeof(NewOrderValidator));
    builder.Services.AddCors();
    builder.Services.AddIdentityServices();
    builder.Services.AddAuthServices(builder.Configuration);
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    app.UseStaticFiles();
    app.UseAuthentication();
    app.UseAuthorization();

    Endpoints.Map(app);

    app.Run();
}