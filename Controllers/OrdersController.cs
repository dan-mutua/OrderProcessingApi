using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly OrderContext _context;
    private readonly OrderPublisher _orderPublisher;

    public OrdersController(OrderContext context, OrderPublisher orderPublisher)
    {
        _context = context;
        _orderPublisher = orderPublisher;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder([FromBody] Order order)
    {
        order.Status = "Placed";
        order.CreatedAt = DateTime.UtcNow;
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        await _orderPublisher.PublishOrderEventAsync(new OrderEvent
        {
            OrderId = order.Id,
            EventType = "OrderPlaced",
            Timestamp = DateTime.Now
        });

        return Ok(order);
    }
}
