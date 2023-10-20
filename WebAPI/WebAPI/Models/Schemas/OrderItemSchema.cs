namespace WebAPI.Models.Schemas;

public class OrderItemSchema
{
    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public int Quantity { get; set; }
}