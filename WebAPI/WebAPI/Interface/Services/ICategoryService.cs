using WebAPI.Models.Dtos;

namespace WebAPI.Interface.Services;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
}
