using src.DataAccess;

namespace src.BusinessLigic;

public sealed class ProService : IProService
{
    private readonly IInfrastructure _infrastructure;

    public ProService(IInfrastructure infrastructure)
    {
        _infrastructure = infrastructure;
    }
    public async Task<ResultCheckStatus> CheckStatus(CheckStatus chackStatus, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(chackStatus);
        return await _infrastructure.CheckStatus(chackStatus,token);
    }

    public async Task<ResultPay> Pay(Pay pay, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(pay);
        return await _infrastructure.Pay(pay,token);
    }
}