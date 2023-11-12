using Microsoft.AspNetCore.Http.HttpResults;
using MinimalAPI.Data;
using MinimalAPI.Handlers;
using MinimalAPI.Tests.Helpers;

namespace MinimalAPI.Tests.UnitTests;

[Collection("Database collection")]
public class CategoriesHandler_Unit
{
    private readonly DataContext _context;

    public CategoriesHandler_Unit(DatabaseFixture fixture)
    {
        _context = fixture.GetContext();
    }

    [Fact]
    public async void GetAll_ShouldReturnAll()
    {
        // Act
        var result = (Ok<string[]>)await CategoriesHandler.GetAll(_context);

        // Assert
        Assert.Equal(3, result.Value?.Length);
        Assert.Equal("Pants", result.Value?[0]);
    }
}