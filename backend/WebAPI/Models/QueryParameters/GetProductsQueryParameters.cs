using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Models.QueryParameters;

public class GetProductsQueryParameters
{
    [FromQuery(Name = "tag")]
    public string? TagName { get; set; }
    [FromQuery(Name = "category")]
    public string? CategoryName { get; set; }
    [FromQuery(Name = "orderBy")]
    public string? OrderBy { get; set; }
    [FromQuery(Name = "page")]
    public int Page { get; set; } = 0;
    [FromQuery(Name = "amount")]
    public int PageAmount { get; set; } = 32;
}