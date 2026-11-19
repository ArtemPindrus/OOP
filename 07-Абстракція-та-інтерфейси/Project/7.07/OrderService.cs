namespace Project;

public class OrderService {
    private readonly ILogger logger;

    public OrderService(ILogger logger) => this.logger = logger;

    public bool PlaceOrder(Order order) {
        try {
            Validate(order);
            logger.Log(LogLevel.Info, $"Order #{order.Id} placed: {order.Quantity} x {order.Item}");
            return true;
        } catch (ArgumentException ex) {
            logger.Log(LogLevel.Error, $"Order #{order.Id} failed: {ex.Message}");
            return false;
        }
    }

    private static void Validate(Order order) {
        if (string.IsNullOrWhiteSpace(order.Item))
            throw new ArgumentException("item is empty");
        if (order.Quantity <= 0)
            throw new ArgumentException("quantity must be positive");
    }
}