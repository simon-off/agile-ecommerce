using System.Linq.Expressions;
using WebAPI.Helpers.Repositories;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Services;

public class ProductService
{
    private readonly ProductRepo _productRepo;

    public ProductService(ProductRepo productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var dtos = new List<ProductDto>();
        var entities = await _productRepo.GetAllAsync();

        foreach (var entity in entities)
            dtos.Add(entity);

        return dtos;
    }

    public async Task<List<ProductDto>> GetAllFilteredAsync(List<Expression<Func<ProductEntity, bool>>> predicates)
    {
        var dtos = new List<ProductDto>();
        var entities = await _productRepo.GetAllAsync(predicates);

        foreach (var entity in entities)
            dtos.Add(entity);

        return dtos;
    }
}
