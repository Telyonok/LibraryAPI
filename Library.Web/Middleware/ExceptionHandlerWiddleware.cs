using FluentValidation;
using Library.Application.Exceptions;
using Library.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Library.Web.Middleware
{
    public class ExceptionHandlerWiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerWiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            Console.WriteLine(typeof(Exception));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            string message;
            if (statusCode == StatusCodes.Status500InternalServerError)
                message = Constants.UnknownErrorMessage;
            else
                message = exception.Message;
            var result = JsonSerializer.Serialize(new { error = message });
            return context.Response.WriteAsync(result);
        }

        private static int GetStatusCode(Exception exception)
        {
            switch (exception)
            {
                case (EntityAlreadyExistsException):
                    return StatusCodes.Status403Forbidden;
                case (EntityNotFoundException):
                    return StatusCodes.Status404NotFound;
                case (ValidationException):
                    return StatusCodes.Status400BadRequest;
                default:
                    return StatusCodes.Status500InternalServerError;
            };
        }
    }
}
