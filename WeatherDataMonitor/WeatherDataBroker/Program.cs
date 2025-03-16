using WeatherDataBroker.DI;
using WeatherDataBroker.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile("appsettings.Development.json", optional: true)
    .Build();
var brokerSettings = WeatherDataBrokerSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);
ApplicationConfigurator.ConfigureServices(builder, brokerSettings);

var app = builder.Build();
ApplicationConfigurator.ConfigureApplication(app, brokerSettings);

app.Run();