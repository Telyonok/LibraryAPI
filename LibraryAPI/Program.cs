using FluentValidation;
using Library.BLL.Services;
using Library.DAL.Repositories;
using Library.Domain.Abstractions;
using Library.Domain.Data;
using Library.Domain.Models;
using LibraryAPI.Helpers;
using LibraryAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var cryptoSettingsSection = builder.Configuration.GetSection("CryptoSettings");
builder.Services.Configure<CryptoSettings>(cryptoSettingsSection);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "localhost:7138",
            ValidAudience = "localhost:7138",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cryptoSettingsSection["JwtSigningKey"])),
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAutoMapper(typeof(BookProfile));
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IValidator<BookRequest>, BookRequestValidator>();
builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// if (app.Environment.IsDevelopment())

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
