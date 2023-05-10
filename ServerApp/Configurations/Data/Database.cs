using Tartaro.Data;

namespace Tartaro.Configurations.Data
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
