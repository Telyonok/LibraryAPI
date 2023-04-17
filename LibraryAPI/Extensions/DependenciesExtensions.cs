using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Library.BusinessLayer.Services.AuthenticationService;
using Library.BusinessLayer.Services.BookService;
using Library.BusinessLayer.Interfaces;
using Library.DataLayer.Interfaces;
using Library.DataLayer.Repositories;
using Library.DataLayer.DatabaseData;
using Library.DomainLayer.Models;

namespace Library.Web.Extensions
{
    public static class DependenciesExtensions
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IValidator<Book>, BookValidator>();
            services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
                ));
        }
    }
}
