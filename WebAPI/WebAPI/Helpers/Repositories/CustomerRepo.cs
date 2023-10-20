using WebAPI.Data;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class CustomerRepo : GenericRepo<CustomerEntity>
{
    public CustomerRepo(DataContext context) : base(context)
    {
    }
}
