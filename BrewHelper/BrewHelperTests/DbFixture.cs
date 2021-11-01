using BrewHelper;
using BrewHelper.Authentication;
using BrewHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using BrewHelper.Authentication.Context;
using Xunit;

namespace BrewHelperTests
{
    public class DbFixture : IDisposable
    {
        private readonly BrewhelperContext _dbContext;
        private readonly AuthenticationDbContext _authDbContext;
        public readonly string TestDbName = $"BrewHelperTest-{Guid.NewGuid()}";
        public readonly string ConnString;
        public readonly string AuthConnString;

        private bool _disposed;

        public DbFixture()
        {
            ConnString = $"Server=localhost,1433;Database={TestDbName};User=sa;Password=BrewHelperDev1!;";

            var builder = new DbContextOptionsBuilder<BrewhelperContext>();
            var userBuilder = new DbContextOptionsBuilder<AuthenticationDbContext>();

            builder.UseSqlServer(ConnString);
            _dbContext = new BrewhelperContext(builder.Options);
            _dbContext.Database.Migrate();

            userBuilder.UseSqlServer(ConnString);
            _authDbContext = new AuthenticationDbContext(userBuilder.Options);
            _authDbContext.Database.Migrate();

            TestDataSeeder.Seed(_dbContext);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // remove the temp db from the server once all tests are done
                    _dbContext.Database.EnsureDeleted();
                }

                _disposed = true;
            }
        }
    }

    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
