namespace Library.Web.Extensions
{
    public static class CorsExtensions
    {
        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        public static void UseCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors("AllowAll");
        }
    }
}
