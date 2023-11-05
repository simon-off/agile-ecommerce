using WebAPI.Data;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class StatusRepo : GenericRepo<StatusEntity>, IStatusRepo
{
    public StatusRepo(DataContext context) : base(context)
    {
    }
}
