using WebAPI.Interface.Repositories;
using WebAPI.Interface.Services;
using WebAPI.Models.Dtos;

namespace WebAPI.Helpers.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepo _categoryRepo;

    public CategoryService(ICategoryRepo categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var dtos = new List<CategoryDto>();
        var entities = await _categoryRepo.GetAllAsync();

        foreach (var entity in entities)
            dtos.Add(entity);

        return dtos;
    }
}
