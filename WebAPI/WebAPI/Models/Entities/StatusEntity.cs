using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Entities;

public class StatusEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
}