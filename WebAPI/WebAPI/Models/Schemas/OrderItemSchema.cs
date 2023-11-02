using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Schemas;

public class OrderItemSchema
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    public required string Size { get; set; }

    [Required]
    public int Quantity { get; set; }
}
