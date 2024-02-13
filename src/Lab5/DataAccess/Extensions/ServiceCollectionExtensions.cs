using AtmApi.Implementations;
using AtmApi.Interfaces;
using AtmRepositoryAdapter;
using DbRepositoryImpl;
using Domain.Ports.Primary;
using Domain.Ports.Secondary;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddScoped<IDbRepository, DbRepository>();
        collection.AddScoped<IAtmRepository, AtmRepository>();

        return collection;
    }

    public static IServiceCollection AddApiService(
        this IServiceCollection collection)
    {
        collection.AddScoped<IAtmState, UnauthorizedAtmState>();
        collection.AddScoped<IAtmService, AtmService>();

        return collection;
    }
}