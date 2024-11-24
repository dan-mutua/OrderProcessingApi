using MassTransit;

public class OrderPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public OrderPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishOrderEventAsync(OrderEvent orderEvent)
    {
        await _publishEndpoint.Publish(orderEvent);
    }
}
