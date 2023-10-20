using WebAPI.Data;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class OrderItemRepo : GenericRepo<OrderItemEntity>
{
    public OrderItemRepo(DataContext context) : base(context)
    {
    }
}
