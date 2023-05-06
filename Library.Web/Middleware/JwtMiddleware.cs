using Library.Domain.Helpers;

namespace Library.Web.Middleware
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
