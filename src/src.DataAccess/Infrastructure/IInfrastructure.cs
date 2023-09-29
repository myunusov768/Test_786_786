

namespace src.DataAccess;


public interface IInfrastructure
{
    //ResultPay
    public Task<string> PayAsync(Pay pay, CancellationToken token = default);
    //ResultCheckStatus
    public Task<string> CheckStatusAsync(CheckStatus chackStatus, CancellationToken token = default);
}