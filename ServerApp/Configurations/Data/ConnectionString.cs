using Caronte.Infra.Configs;

namespace Tartaro.Configurations.Data
{
    public static class ConnectionString
    {
        public static IServiceCollection BindConnectionStringToModel(WebApplicationBuilder builder)
        {
            builder.Services.Configure<DatabaseConnectionStringModel>(builder.Configuration.GetSection("ConnectionString"));
            return builder.Services;
        }
    }
}
