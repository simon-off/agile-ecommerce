using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    x => x.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoints
Endpoints.Map(app);

app.Run();
