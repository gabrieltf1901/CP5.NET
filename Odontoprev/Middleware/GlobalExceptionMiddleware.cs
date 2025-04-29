using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Odontoprev.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Tratamento de exceções
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Ocorreu um erro interno.");
                // Aqui você pode inserir lógica de log, etc.
            }
        }
    }
}