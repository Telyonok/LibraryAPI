using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Library.Application.Interfaces;
using Library.Infrastructure.Authentication.JwtBearerSettings;
using Library.Infrastructure.Authentication;

namespace Library.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
                ));
            services.AddScoped<ILibraryDbContext, LibraryDbContext>();
            services.Configure<JwtBearerAuthenticationOptions>(configuration.GetSection("JwtBearerAuthentication"));
            services.ConfigureOptions<JwtBearerAuthenticationConfigurator>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer();

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
