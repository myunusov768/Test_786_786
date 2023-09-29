using src.DataAccess;

namespace src.BusinessLigic;

public sealed class SheckService : ISheckService
{
    private readonly ICheckInfrastructure _infrastructure;
    private readonly AppSettings _appSettings;
    private readonly HashingMd5 _hashingMd5;

    public SheckService(ICheckInfrastructure infrastructure, AppSettings appSettings, HashingMd5 hashingMd5)
    {
        ArgumentNullException.ThrowIfNull(infrastructure);
        _infrastructure = infrastructure;
        _appSettings = appSettings;
        _hashingMd5 = hashingMd5;
    }

    public async Task<CheckResponse> CheckAccount(CheckDto chack, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(chack);
        var check = chack.ToCheckExtension();
        check.Action = _appSettings.Actions["check"];
        check.UserId = _appSettings.UserId;
        check.Hash = _hashingMd5.GetHashChech(check.Account);
        var result = await _infrastructure.CheckAccount(check,token);
        if(result.Code == 1)
        {
            return new CheckResponse(){ code = result.Code, description = result.Message, choice = result.ToPay.ToPayExtension(), prv_answer = result.Code};
        }
        else
        {
            return new CheckResponse(){ code = -1, description = result.Message, choice = result.ToPay.ToPayExtension(), prv_answer = result.Code};
        }
    }
}