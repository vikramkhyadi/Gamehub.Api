using Gamehub.Application;
using Gamehub.Infrastructure.Database;
using Gamehub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Gamehub.Api;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddApplication(this IServiceCollection services, string connectionString)
    {
        services.AddSqlDatabase(connectionString);
        services.AddServices();
        return services;
    }

    public static IServiceCollection AddSqlDatabase(this IServiceCollection services, string connectionString)
    {

        services.AddDbContext<ApplicationDBContext>(
            v =>
            {
                v.UseSqlServer(connectionString);
            });
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGamesService, GamesService>();
        services.AddScoped<IGameRepository, GameRepository>();
        return services;
    }

}
