using System.Linq.Expressions;
using WebAPI.Models.Entities;

namespace WebAPI.Interface.Repositories;

public interface IProductRepo : IRepo<ProductEntity>
{
    Task<List<ProductEntity>> GetAllAsync(List<Expression<Func<ProductEntity, bool>>> predicates);
}
