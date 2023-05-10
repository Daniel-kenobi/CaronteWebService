namespace Tartaro.Configurations.Data
{
    public static class ConnectionString
    {
        public static IServiceCollection BindConnectionStringToModel(WebApplicationBuilder builder)
        {
            builder.Services.Configure<Barsa.Models.Database>(builder.Configuration.GetSection("ConnectionString"));
            return builder.Services;
        }
    }
}
