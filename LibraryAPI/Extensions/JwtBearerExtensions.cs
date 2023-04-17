using Library.DomainLayer.JwtBearerOptions;
using Library.Web.JwtBearerSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace Library.Web.Extensions
{
    public static class JwtBearerExtensions
    {
        public static void ConfigureJwtBearer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtBearerAuthenticationOptions>(configuration.GetSection("JwtBearerAuthentication"));
            services.ConfigureOptions<JwtBearerAuthenticationConfigurator>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
        }
    }
}
