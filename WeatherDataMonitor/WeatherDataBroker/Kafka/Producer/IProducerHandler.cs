using Confluent.Kafka;

namespace WeatherDataBroker.Kafka.Producer;

public interface IProducerHandler
{
    public DeliveryResult<Null, string>? Send(string message, CancellationToken stoppingToken);
}