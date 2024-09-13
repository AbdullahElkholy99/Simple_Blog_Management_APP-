using SimpleBlog.Data;
using SimpleBlog.Service;

namespace SimpleBlog.Extentions
{

    public static class ExtentionsServices
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });
        public static void ConfigureSqlServer(this IServiceCollection services
            , IConfiguration builder) =>
            services.AddSqlServer<AppDbContext>(builder.GetConnectionString("sqlConnection"));
        public static void ConfigureBlogService (this IServiceCollection services) =>
          services.AddScoped<IBlogService, BlogService>();


    }
}
