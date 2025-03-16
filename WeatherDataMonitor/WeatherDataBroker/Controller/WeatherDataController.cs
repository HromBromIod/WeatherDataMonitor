using System.Text.Json;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using WeatherDataBroker.Kafka.Producer;
using ILogger = Serilog.ILogger;

namespace WeatherDataBroker.Controller;

[ApiController]
[Route("[controller]")]
public class WeatherDataController(ILogger logger, IProducerHandler producerHandler) : ControllerBase
{
    [HttpPost]
    [Route("send")]
    public IActionResult Post([FromBody] string message, CancellationToken stoppingToken)
    {
        if (message is null || message.Equals(string.Empty))
        {
            const string resultMessage = "Empty query message.";
            logger.Information(resultMessage);
            return BadRequest(resultMessage);
        }

        var jsonStringMessage = JsonSerializer.Serialize(message);
        var result = producerHandler.Send(jsonStringMessage, stoppingToken);
        if (result is not null && result.Status != PersistenceStatus.NotPersisted)
        {
            return Ok();
        }
        
        logger.Error("Kafka error");
        return StatusCode(500, "Internal server error");
    }
}