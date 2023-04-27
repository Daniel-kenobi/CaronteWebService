using Tartaro.Data;

namespace Tartaro.Configurations
{
    public static class Database
    {
        public static IServiceCollection ConfigureDbContext(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>();
            return builder.Services;
        }
    }
}
