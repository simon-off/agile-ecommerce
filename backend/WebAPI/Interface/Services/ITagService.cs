using WebAPI.Models.Dtos;

namespace WebAPI.Interface.Services;

public interface ITagService
{
    Task<List<TagDto>> GetAllAsync();
}
