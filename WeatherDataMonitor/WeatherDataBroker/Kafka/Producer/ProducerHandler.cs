using Confluent.Kafka;
using WeatherDataBroker.Settings;
using ILogger = Serilog.ILogger;

namespace WeatherDataBroker.Kafka.Producer;

public class ProducerHandler(ILogger logger, WeatherDataBrokerSettings settings) : IProducerHandler
{
    public DeliveryResult<Null, string>? Send(string message, CancellationToken stoppingToken)
    {
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = settings.BootstrapServersUri
        };
        using var producer =
            new ProducerBuilder<Null, string>(producerConfig).Build();
        try
        {
            return producer.ProduceAsync(settings.TopicName, new Message<Null, string> { Value = message }, stoppingToken)
                .GetAwaiter()
                .GetResult();
        }
        catch (Exception e)
        {
            logger.Error($"Something went wrong: {e}");
        }

        return null;
    }
}