namespace WeatherDataBroker.Settings;

public static class WeatherDataBrokerSettingsReader
{
    public static WeatherDataBrokerSettings Read(IConfiguration configuration)
    {
        return new WeatherDataBrokerSettings
        {
            TopicName = configuration.GetSection("Kafka").GetValue<string>("TopicName"),
            BootstrapServersUri = configuration.GetSection("Kafka").GetValue<string>("BootstrapServersUri")
        };
    }
}