This project contains three classes: ILogger, ConsoleLogger and TimePrefixLoggerDecorator.

ILogger is an abstraction for logging functionality objects may depend on.
ConsoleLogger is a concrete implementation of ILogger that delegates logging to the Console class.
TimePrefixLoggerDecorator is a decorator class that adds a timestamp prefix to log messages before delegating the call to an instance of ILogger.

The most interesting class in here is TimePrefixLoggerDecorator.
It implements the Decorator Pattern, which allows you to extend the functionality of an object without modifying its class (OCP).
It contains:
- a private readonly field of type ILogger that is initialized in the constructor.
- constructor that takes an ILogger instance and assigns it to the private field.
- a LogInfo method that takes a string, prepends a timestamp to it, and then delegates call to the decoratee.


Program class composes an ILogger object graph and demonstrates its usage.