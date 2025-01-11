using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Test.Millon.Core.Exceptions;

namespace Test.Millon.API.Services
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error no controlado en la API.");

                context.Response.ContentType = "application/json";
                object response = new { };

                switch (ex)
                {
                    case InvalidPropertyNameException invalidNameEx:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        response = new { StatusCode = (int)HttpStatusCode.BadRequest, Message = invalidNameEx.Message };
                        break;
                    case PropertyNotFoundException notFoundEx:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        response = new { StatusCode = (int)HttpStatusCode.NotFound, Message = notFoundEx.Message };
                        break;
                    // Otros casos específicos para excepciones de dominio
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        response = new { StatusCode = (int)HttpStatusCode.InternalServerError, Message = "Un error interno ha ocurrido. Por favor, inténtelo de nuevo más tarde." }; // Mensaje genérico para el usuario
                        break;
                }

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
