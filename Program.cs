using Caronte.DependencyInjection.Client;
using MediatR;
using Tartaro.Configurations.Authentication;
using Tartaro.Configurations.Data;

internal partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Authentication.AddJWTAuthentication(builder);
        ConnectionString.BindConnectionStringToModel(builder);
        Database.ConfigureDbContext(builder);

        builder.Services.AddMediatR(typeof(Program));
        builder.Services.AddControllersWithViews();
        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
            app.UseHsts();

        app.UseCors("MyPolicy");
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseStaticFiles();
        app.UseRouting();

        app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");
        app.Run();
    }
}