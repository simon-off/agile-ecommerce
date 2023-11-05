using WebAPI.Data;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class SizeRepo : GenericRepo<SizeEntity>, ISizeRepo
{
    public SizeRepo(DataContext context) : base(context)
    {
    }
}
