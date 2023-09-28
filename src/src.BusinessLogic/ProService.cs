using src.DataAccess;

namespace src.BusinessLigic;

public sealed class ProService : IProService
{
    private readonly IInfrastructure _infrastructure;

    public ProService(IInfrastructure infrastructure)
    {
        _infrastructure = infrastructure;
    }

    public Task<ResultChack> CheckAccount(Check chack, CancellationToken token = default)
    {
        return _infrastructure.CheckAccount(chack,token);
    }

    public Task<ResultCheckStatus> CheckStatus(CheckStatus chackStatus, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<ResultPay> Pay(Pay pay, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}