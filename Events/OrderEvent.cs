public class OrderEvent
{
    public int OrderId { get; set; }
    public string EventType { get; set; } // e.g., "OrderPlaced"
    public DateTime Timestamp { get; set; }
}
