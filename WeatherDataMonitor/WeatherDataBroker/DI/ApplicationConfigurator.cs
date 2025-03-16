using WeatherDataBroker.IoC;
using WeatherDataBroker.Settings;

namespace WeatherDataBroker.DI;

public static class ApplicationConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder, WeatherDataBrokerSettings settings)
    {
        SerilogConfigurator.ConfigureServices(builder);
        SwaggerConfigurator.ConfigureServices(builder.Services);
        ServicesConfigurator.ConfigureServices(builder.Services, settings);
        builder.Services.AddControllers();
    }

    public static void ConfigureApplication(WebApplication app, WeatherDataBrokerSettings settings)
    {
        SerilogConfigurator.ConfigureApplication(app);
        SwaggerConfigurator.ConfigureApplication(app);
        app.MapControllers();
    }
}