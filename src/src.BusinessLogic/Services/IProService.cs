using src.DataAccess;

namespace src.BusinessLigic;

public interface IProService
{
    public Task<ResultPay> Pay(Pay pay, CancellationToken token = default);
    public Task<ResultCheckStatus> CheckStatus(CheckStatus chackStatus, CancellationToken token = default);
}