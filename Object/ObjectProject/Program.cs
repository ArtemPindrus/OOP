using ObjectProject.Services;

ILogger logger = new TimePrefixLoggerDecorator(new ConsoleLogger());

logger.LogInfo("Hello, Overengineered World!");

await Task.Delay(1000);

logger.LogInfo("Hello, again!");