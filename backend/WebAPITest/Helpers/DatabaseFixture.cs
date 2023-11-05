using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPITest.Helpers;


[CollectionDefinition("Database collection")]
public class DatbaseCollection : ICollectionFixture<DatabaseFixture>
{
    // This class has no code, and is never created. Its purpose is simply to be the place to apply [CollectionDefinition] and all the interfaces
}

public class DatabaseFixture : IDisposable
{
    private DataContext _context;

    public DatabaseFixture()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        _context = new DataContext(options);
        var seeder = new SeederTestDatabase(_context);

        seeder.SeedProductsMockDatabase();
    }

    public DataContext CreateContext()
    {
        return _context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
