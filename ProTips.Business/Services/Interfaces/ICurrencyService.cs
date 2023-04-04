using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Services.Interfaces;

public interface ICurrencyService : IService<Currency>
{
    Task<Currency> CreateAsync(CurrencyDto model);
}