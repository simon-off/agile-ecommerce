using WebAPI.Data;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class CustomerRepo : GenericRepo<CustomerEntity>, ICustomerRepo
{
    public CustomerRepo(DataContext context) : base(context)
    {
    }
}
