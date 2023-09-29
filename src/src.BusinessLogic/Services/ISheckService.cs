using src.DataAccess;

namespace src.BusinessLigic;

public interface ISheckService
{
    public Task<CheckResponse> CheckAccountAsync(CheckDto check, CancellationToken token = default);
}