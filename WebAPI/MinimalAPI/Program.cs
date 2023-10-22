using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MinimalAPI.Models.Dtos;
using MinimalAPI.Validators;
using MinimalAPI.Data;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));
    builder.Services.AddScoped<IValidator<NewOrderDto>, NewOrderValidator>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    try
    {
        Endpoints.Map(app);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    app.Run();
}