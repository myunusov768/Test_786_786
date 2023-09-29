using src.DataAccess;

namespace src.BusinessLigic;

public interface ISheckService
{
    public Task<CheckResponse> CheckAccount(CheckDto check, CancellationToken token = default);
}