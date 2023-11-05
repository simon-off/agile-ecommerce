using System.Linq.Expressions;
using WebAPI.Models.Entities;
using WebAPI.Models.QueryParameters;

namespace WebAPI.Interface.Repositories;

public interface IProductRepo : IRepo<ProductEntity>
{
    Task<List<ProductEntity>> GetAllAsync(GetProductsQueryParameters queryParameters);
    Task<int> GetProductCount(string? tagName, string? categoryName);
}
