using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace CaronteWebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices(ConfigureServices)
                .Configure(Configure);
        }

        private static void ConfigureAppConfiguration(WebHostBuilderContext hostingContext, IConfigurationBuilder configBuilder)
        {
            configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configBuilder.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
            configBuilder.AddEnvironmentVariables();
        }

        private static void ConfigureServices(WebHostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(ConfigureSwaggerGen);
        }

        private static void ConfigureSwaggerGen(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Caronte", Version = "v1" });
        }

        private static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(ConfigureSwaggerUI);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void ConfigureSwaggerUI(SwaggerUIOptions options)
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Caronte");
            options.RoutePrefix = string.Empty;
        }
    }
}
