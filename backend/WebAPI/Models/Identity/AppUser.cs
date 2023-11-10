using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;

namespace WebAPI.Models.Identity;

public class AppUser : IdentityUser
{
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; } = null!;

    public List<OrderEntity> Orders { get; set; } = new();

    public static implicit operator UserDto(AppUser model)
    {
        return new UserDto
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email!,
            PhoneNumber = model.PhoneNumber!
        };
    }
}
