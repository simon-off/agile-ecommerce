using WebAPI.Data;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class CategoryRepo : GenericRepo<CategoryEntity>, ICategoryRepo
{
    public CategoryRepo(DataContext context) : base(context)
    {
    }
}
