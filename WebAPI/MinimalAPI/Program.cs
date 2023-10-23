using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Data;
using MinimalAPI;
using MinimalAPI.Helpers.Validators;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));
    builder.Services.AddScoped<IValidator<NewOrderDto>, NewOrderValidator>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/error");
    Endpoints.Map(app);
    app.Run();
}