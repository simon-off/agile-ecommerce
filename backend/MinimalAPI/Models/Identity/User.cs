using Microsoft.AspNetCore.Identity;
using MinimalAPI.Models.Entities;

namespace MinimalAPI.Models.Identity;

public class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public List<Order> Orders { get; set; } = new();
}
