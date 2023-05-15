using Library.Web.Middleware;
using Library.Application;
using Library.Infrastructure;
using Library.Web.Profiles;
using Library.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCorsPolicy();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(BookProfile));
builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCorsPolicy();
app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ExceptionHandlerWiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
