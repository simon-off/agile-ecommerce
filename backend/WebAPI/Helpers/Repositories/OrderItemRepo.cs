using WebAPI.Data;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class OrderItemRepo : GenericRepo<OrderItemEntity>, IOrderItemRepo
{
    public OrderItemRepo(DataContext context) : base(context)
    {
    }
}
