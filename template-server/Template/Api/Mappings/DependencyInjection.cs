using System.Reflection;
using Mapster;

namespace Api.Mappings;

public static class DependencyInjection
{
    public static void AddMapsteMappings(this IServiceCollection services)
    {
        TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
    }
}
