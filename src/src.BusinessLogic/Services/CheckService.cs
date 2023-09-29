using System.Text.Json;
using Microsoft.Extensions.Logging;
using src.DataAccess;

namespace src.BusinessLigic;

public sealed class SheckService : ISheckService
{
    private readonly ICheckInfrastructure _infrastructure;
    private readonly AppSettings _appSettings;
    private readonly HashingMd5 _hashingMd5;
    private readonly ILogger logger;

    public SheckService(ICheckInfrastructure infrastructure, AppSettings appSettings, HashingMd5 hashingMd5, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(infrastructure);
        _infrastructure = infrastructure;
        _appSettings = appSettings;
        _hashingMd5 = hashingMd5;
        this.logger = logger;
    }

    public async Task<CheckResponse> CheckAccountAsync(CheckDto chack, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(chack);
        var check = chack.ToCheckExtension();
        check.Action = _appSettings.Actions["check"];
        check.UserId = _appSettings.UserId;
        check.Hash = _hashingMd5.GetHashChech( check.Account );
        var result = await _infrastructure.CheckAccountAsync( check, token);
        if(result is null)
            return new CheckResponse(){ code = -1, description = "Null error!"};

        var resultParse = JsonSerializer.Deserialize<ResultChack>(result)!;

        if(resultParse.Code == 1)
            return new CheckResponse(){ code = resultParse.Code, description = resultParse.Message, choice = resultParse.ToPay.ToPayExtension(), prv_answer = result};
        
        return new CheckResponse(){ code = -1, description = resultParse.Message, choice = resultParse.ToPay.ToPayExtension(), prv_answer = result};
    }
}