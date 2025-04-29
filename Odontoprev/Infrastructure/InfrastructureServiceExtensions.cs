using Microsoft.Extensions.DependencyInjection;

namespace Odontoprev.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Registre aqui os serviços da camada de Infrastructure.
        return services;
    }
}