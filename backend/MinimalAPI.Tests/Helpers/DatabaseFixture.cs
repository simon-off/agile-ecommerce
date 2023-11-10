using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;

namespace MinimalAPI.Tests.Helpers;


[CollectionDefinition("Database collection")]
public class DatbaseCollection : ICollectionFixture<DatabaseFixture>
{
    // This class has no code, and is never created.
    // Its purpose is simply to be the place to apply [CollectionDefinition] and all the interfaces
}

public class DatabaseFixture : IDisposable
{
    private readonly DataContext _context;

    public DatabaseFixture()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        _context = new DataContext(options);

        TestSeeder.Seed(_context);
    }

    public DataContext CreateContext() => _context;

    public void Dispose()
    {
        _context.Dispose();
    }
}
