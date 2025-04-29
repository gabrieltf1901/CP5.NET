using Microsoft.Extensions.DependencyInjection;

namespace Odontoprev.Presentation;

public static class PresentationServiceExtensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        // Registre aqui os serviços da camada de Presentation.
        return services;
    }
}