using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Odontoprev.Presentation.Extensions;

public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Odontoprev API",
                Version = "v1",
                Description = "API para gerenciamento de atendimentos odontológicos e análise preditiva de sinistros."
            });

            // Para leitura de XML comments (caso habilite no csproj)
            var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
            if (File.Exists(xmlPath))
            {
                c.IncludeXmlComments(xmlPath);
            }
        });

        return services;
    }
}