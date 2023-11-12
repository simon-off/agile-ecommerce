using Microsoft.AspNetCore.Http.HttpResults;
using MinimalAPI.Data;
using MinimalAPI.Handlers;
using MinimalAPI.Tests.Helpers;

namespace MinimalAPI.Tests.UnitTests;

[Collection("Database collection")]
public class TagsHandler_Unit
{
    private readonly DataContext _context;

    public TagsHandler_Unit(DatabaseFixture fixture)
    {
        _context = fixture.GetContext();
    }

    [Fact]
    public async void GetAll_ShouldReturnAll()
    {
        // Act
        var result = (Ok<string[]>)await TagsHandler.GetAll(_context);

        // Assert
        Assert.Equal(3, result.Value?.Length);
        Assert.Equal("Popular", result.Value?[0]);
    }
}