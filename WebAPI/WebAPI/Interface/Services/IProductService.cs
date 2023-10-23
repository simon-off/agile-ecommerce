using System.Linq.Expressions;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;

namespace WebAPI.Interface.Services;

public interface IProductService
{
    Task<ProductDto?> GetById(int id);
    Task<List<ProductDto>> GetAllAsync();
    Task<List<ProductDto>> GetAllFilteredAsync(List<Expression<Func<ProductEntity, bool>>> predicates);
}
