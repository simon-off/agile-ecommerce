using WebAPI.Data;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class AddressRepo : GenericRepo<AddressEntity>
{
    public AddressRepo(DataContext context) : base(context)
    {
    }
}
