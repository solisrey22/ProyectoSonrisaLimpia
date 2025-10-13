using SonrisaLimpia.Aplicacion.Excepciones;
using System.Net;
using System.Text.Json;

namespace SonrisaLimpia.API.Middleware
{
    public class ManejadorExcepcionesMW(RequestDelegate next, ILogger<ManejadorExcepcionesMW> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ManejadorExcepcionesMW> _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ManejadorExcepciones(context, ex);
            }
        }

        private Task ManejadorExcepciones (HttpContext context, Exception excepcion) 
        {
           HttpStatusCode codigoEstado = HttpStatusCode.InternalServerError;
           context.Response.ContentType = "application/json";
           var resultado = string.Empty;

            switch(excepcion)
            {
                case ExcepcionNoEncontrado:
                    codigoEstado = HttpStatusCode.NotFound;
                    break;
                case ExcepcionDeValidacion excepcionDeValidacion:
                    codigoEstado = HttpStatusCode.BadRequest;
                    resultado = JsonSerializer.Serialize(excepcionDeValidacion.ErroresDeValidacion);
                    break;
            }
            context.Response.StatusCode = (int)codigoEstado;
            return context.Response.WriteAsync(resultado);
        }

    }

    public static class ManejadorExcepcionesMWExtensions
    {
        public static IApplicationBuilder UseManejadorExcepciones(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ManejadorExcepcionesMW>();
        }
    }
}
