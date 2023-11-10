using Microsoft.AspNetCore.Identity;

namespace MinimalAPI.Models.Entities;

public class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public List<Order> Orders { get; set; } = new();
}
