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

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var entity = await _productRepo.GetAsync(x => x.Id == id);

        if (entity == null)
            return null;

        return entity;
    }

    public async Task<List<ProductDto>> GetAllAsync(
        string? tagName = null,
        string? categoryName = null,
        string? orderBy = null)
    {
        var dtos = new List<ProductDto>();
        var entities = await _productRepo.GetAllAsync(tagName, categoryName, orderBy);

        foreach (var entity in entities)
            dtos.Add(entity);

        return dtos;
    }
}
