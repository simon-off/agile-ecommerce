using WebAPI.Data;
using WebAPI.Interface.Repositories;
using WebAPI.Models.Entities;

namespace WebAPI.Helpers.Repositories;

public class BankCardRepo : GenericRepo<BankCardEntity>, IBankCardRepo
{
    public BankCardRepo(DataContext context) : base(context)
    {
    }
}
