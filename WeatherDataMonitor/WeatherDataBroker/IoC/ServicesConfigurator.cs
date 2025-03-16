using WeatherDataBroker.Kafka.Producer;
using WeatherDataBroker.Settings;
using ILogger = Serilog.ILogger;

namespace WeatherDataBroker.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services, WeatherDataBrokerSettings settings)
    {
        services.AddSingleton<IProducerHandler>(x => new ProducerHandler(
            x.GetRequiredService<ILogger>(),
            settings));
    }
}