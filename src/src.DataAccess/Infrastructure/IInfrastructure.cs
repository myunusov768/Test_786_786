

namespace src.DataAccess;


public interface IInfrastructure
{
    public Task<ResultChack> CheckAccount(Check chack, CancellationToken token = default);
    public Task<ResultPay> Pay(Pay pay, CancellationToken token = default);
    public Task<ResultCheckStatus> CheckStatus(CheckStatus chackStatus, CancellationToken token = default);
}