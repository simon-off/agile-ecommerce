using WebAPI.Models.Dtos;
using WebAPI.Models.Schemas;

namespace WebAPI.Interface.Services;

public interface IBankCardService
{
    Task<BankCardDto> CreateAsync(BankCardCreateSchema schema, string userId);
    Task<BankCardDto?> GetCard(int cardId);
    Task<List<BankCardDto>> GetAllUserCards(string userId);
    Task<BankCardDto> UpdateAsync(BankCardUpdateSchema schema, string userId);
    Task<bool> IsCardOwnedByUser(int cardId, string userId);
    Task<bool> DeleteCard(int id);
}
