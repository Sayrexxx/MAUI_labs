using ISP.Entities;

namespace ISP.Services;

public interface IRateService
{
    Task<IEnumerable<Rate>?> GetRates(DateTime date);
}