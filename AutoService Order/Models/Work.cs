namespace AutoService_Order.Models;

public class Work
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public string WorkName { get; set; }
    public decimal Price { get; set; }
}