using WebAPI.Data;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class TagRepo : GenericRepo<TagEntity>, ITagRepo
{
    public TagRepo(DataContext context) : base(context)
    {
    }
}
