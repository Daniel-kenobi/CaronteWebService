using Barsa.Models.JWTAppSettingsModel;

namespace Tartaro.Configurations.Authentication
{
    public static class AppSettings
    {
        public static IServiceCollection BindAppSettingsToModel(WebApplicationBuilder builder)
        {
            builder.Services.Configure<JWTAppSettings>(builder.Configuration.GetSection("JwtKeys"));
            return builder.Services;
        }
    }
}
