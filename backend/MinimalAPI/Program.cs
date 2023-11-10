using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MinimalAPI.Validation.Validators;
using MinimalAPI.Data;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));
    builder.Services.AddValidatorsFromAssemblyContaining(typeof(NewOrderValidator));
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    Endpoints.Map(app);
    app.Run();
}