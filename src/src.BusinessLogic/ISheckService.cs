using src.DataAccess;

namespace src.BusinessLigic;

public interface ISheckService
{
    public Task<ResultChack> CheckAccount(Check chack, CancellationToken token = default);
}