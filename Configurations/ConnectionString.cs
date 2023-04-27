namespace Tartaro.Configurations
{
    public static class ConnectionString
    {
        public static IServiceCollection BindConnectionStringToModel(WebApplicationBuilder builder)
        {
            builder.Services.Configure<Barsa.Models.ConnectionString>(builder.Configuration.GetSection("ConnectionString"));
            return builder.Services;
        }
    }
}
