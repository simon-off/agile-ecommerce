using System.Linq.Expressions;
using WebAPI.Interface.Repositories;
using WebAPI.Interface.Services;
using WebAPI.Models.Dtos;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Services;

public class ProductService : IProductService
{
    private readonly IProductRepo _productRepo;

    public ProductService(IProductRepo productRepo)
    {
        _productRepo = productRepo;
    }
    public async Task<ProductDto?> GetById(int id)
    {
        var entity = await _productRepo.GetAsync(x => x.Id == id);

        if (entity == null)
            return null;

        return entity;
    }

    public async Task<ProductDto?> GetById(int id)
    {
        var entity = await _productRepo.GetAsync(x => x.Id == id);

        if (entity == null)
            return null;

        return entity;
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
