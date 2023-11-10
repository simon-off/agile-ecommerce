namespace WebAPI.Models.Schemas;

public class OrderCreateSchema
{
    // Send same id multiple times if you wish to purchase multiple of the same item
    public List<OrderItemSchema> Products { get; set; } = new();
    public AddressCreateSchema Address { get; set; } = null!;
    public CustomerCreateSchema Customer { get; set; } = null!;
    public string? OrderComment { get; set; }
}
