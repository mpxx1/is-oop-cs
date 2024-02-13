using System.Diagnostics.CodeAnalysis;
using Domain.Model.Enums;
using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

namespace DataAccess;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure([NotNull] NpgsqlDataSourceBuilder builder)
    {
        builder
            .MapEnum<SystemRole>()
            .MapEnum<AtmOperation>();
    }
}