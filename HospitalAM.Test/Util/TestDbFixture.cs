using HospitalAM.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HospitalAM.Test.Util
{
    public class TestDbFixture : IDisposable
    {
        public SqliteConnection Connection { get; }
        public DbContextOptions<ApplicationDbContext> Options { get; }

        public TestDbFixture()
        {
            Connection = new SqliteConnection("Filename=:memory:");
            Connection.Open();

            Options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(Connection)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .Options;

            using var ctx = new ApplicationDbContext(Options);
            ctx.Database.EnsureCreated();
        }

        public ApplicationDbContext CreateContext() => new ApplicationDbContext(Options);   

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
