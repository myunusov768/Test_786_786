using src.DataAccess;

namespace src.BusinessLigic;

public sealed class SheckService : ISheckService
{
    private readonly ICheckInfrastructure _infrastructure;

    public SheckService(ICheckInfrastructure infrastructure)
    {
        ArgumentNullException.ThrowIfNull(infrastructure);
        _infrastructure = infrastructure;
    }

    public async Task<ResultChack> CheckAccount(Check chack, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(chack);
        return await _infrastructure.CheckAccount(chack,token);
    }
}