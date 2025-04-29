// Exemplo de classe de extensão para Application Services
using Microsoft.Extensions.DependencyInjection;

namespace Odontoprev.Application;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registre os serviços da camada de Application aqui.
        // Exemplo:
        // services.AddTransient<IAlgumServico, AlgumServico>();
        return services;
    }
}