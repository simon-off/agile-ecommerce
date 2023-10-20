using WebAPI.Data;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class SizeRepo : GenericRepo<SizeEntity>
{
    public SizeRepo(DataContext context) : base(context)
    {
    }
}
