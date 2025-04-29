using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using Odontoprev.Infrastructure;
using Odontoprev.Application;
using Odontoprev.Infrastructure.Data;
using Odontoprev.Presentation;
using Swashbuckle.AspNetCore.SwaggerGen;
using FluentValidation.AspNetCore;
using Odontoprev.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner

// Configuração do DbContext com Oracle
builder.Services.AddDbContext<OracleDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Odontoprev.Infrastructure")));

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();  // Habilita as anotações do Swagger
});

// Injeção de dependência dos serviços da aplicação
builder.Services.AddApplicationServices();  // Configura as dependências da camada de Application
builder.Services.AddInfrastructureServices(); // Configura as dependências da camada de Infrastructure
builder.Services.AddPresentationServices();  // Configura as dependências da camada de Presentation

// Configuração do FluentValidation
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

// Adiciona suporte para Controllers (necessário se você usar controllers)
builder.Services.AddControllers();

var app = builder.Build();

// Middleware de tratamento de erros deve vir no início
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Configuração de redirecionamento para HTTPS (opcional, mas recomendado)
app.UseHttpsRedirection();

// Habilitar Swagger e SwaggerUI em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Caso utilize autenticação/ autorização, adicione os middlewares correspondentes
app.UseAuthorization();

// Configuração dos endpoints dos controllers
app.MapControllers();

// Inicializando a aplicação
app.Run();