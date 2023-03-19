using Library.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Middleware
{
    public class JwtMiddleware
    {
        public RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Cookies[Constants.TokenKey];
            if (token != null) 
                context.Request.Headers.Add("Authorization", $"bearer {token}");
            await _next(context);
        }
    }
}
