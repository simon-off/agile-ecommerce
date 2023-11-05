using System.Linq.Expressions;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;
using WebAPI.Models.QueryParameters;

namespace WebAPI.Interface.Services;

public interface IProductService
{
    Task<ProductDto?> GetByIdAsync(int id);
    Task<List<ProductDto>> GetAllAsync(GetProductsQueryParameters queryParameters);
}
