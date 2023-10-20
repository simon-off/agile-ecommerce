using WebAPI.Data;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class StatusRepo : GenericRepo<StatusEntity>
{
    public StatusRepo(DataContext context) : base(context)
    {
    }
}
