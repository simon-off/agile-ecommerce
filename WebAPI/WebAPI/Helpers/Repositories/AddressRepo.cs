using WebAPI.Data;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;
public class AddressRepo : GenericRepo<AddressEntity>, IAddressRepo
{
    public AddressRepo(DataContext context) : base(context)
    {
    }
}
