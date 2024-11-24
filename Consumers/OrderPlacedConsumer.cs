using MassTransit;

public class OrderPlacedConsumer : IConsumer<OrderEvent>
{
    public async Task Consume(ConsumeContext<OrderEvent> context)
    {
        if (context.Message.EventType == "OrderPlaced")
        {
            Console.WriteLine($"Order {context.Message.OrderId} has been placed.");
        }
    }
}
