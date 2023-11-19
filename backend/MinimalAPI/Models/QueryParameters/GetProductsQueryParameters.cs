namespace WebAPI.Models.QueryParameters;

public record GetProductsQueryParameters(
    string? Category,
    string? Tag,
    string? Sort,
    int Page,
    int Amount
)
{
    public static GetProductsQueryParameters Create(
        string? category,
        string? tag,
        string? sort,
        int? page,
        int? amount) =>
        new(category, tag, sort, page ?? 1, amount ?? 16);
}