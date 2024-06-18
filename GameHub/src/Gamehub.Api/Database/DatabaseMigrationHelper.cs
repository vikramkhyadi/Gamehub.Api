using Microsoft.EntityFrameworkCore;
using Serilog;
using Gamehub.Infrastructure.Database;

namespace Gamehub.Api.Database;

public static class DatabaseMigrationHelper
{
    public static bool ShouldRunDatabaseMigration()
    {
        var migratrionArgSpecified = Environment.GetCommandLineArgs()
            .Any(arg => arg.Equals("ef-migrate", StringComparison.InvariantCultureIgnoreCase));
        return migratrionArgSpecified;
    }


    public static void RunDatabaseMigration(IConfiguration configuration)
    {
        Log.Information("Starting database migration");
        var connectionString = configuration.GetSection("ConnectionStrings").Value;
        var builder = new DbContextOptionsBuilder<ApplicationDBContext>();
        builder.UseSqlServer(connectionString);
        using var db = new ApplicationDBContext(builder.Options, configuration);
        db.Database.Migrate();
        Log.Information("Database migrated successfully");
    }
}
