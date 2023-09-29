using System.Text.Json;
using Microsoft.Extensions.Logging;
using src.DataAccess;

namespace src.BusinessLigic;

public sealed class ProService : IProService
{
    private readonly IInfrastructure _infrastructure;
    private readonly ILogger _logger;

    public ProService(IInfrastructure infrastructure, ILogger logger)
    {
        _infrastructure = infrastructure;
        _logger = logger;
    }
    public async Task<ResultCheckStatus> CheckStatus(CheckStatus chackStatus, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(chackStatus);
        var resultCheckStatus = await _infrastructure.CheckStatusAsync(chackStatus,token);
        if(resultCheckStatus is null)
        {
            throw new ArgumentNullException("resultCheckStatus is null!");
        }
        var checkStatusParse = JsonSerializer.Deserialize<ResultCheckStatus>(resultCheckStatus, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true});
        if(checkStatusParse is null)
            throw new ArgumentNullException("checkStatusParse is null!");
        return checkStatusParse;
    }

    public async Task<ResultPay> Pay(Pay pay, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(pay);
        var resultPay = await _infrastructure.PayAsync(pay,token);
        if(resultPay is null)
        {
            throw new ArgumentNullException("resultPay is null!");
        }
        var resultPayParse = JsonSerializer.Deserialize<ResultPay>(resultPay, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true});
        if(resultPayParse is null)
            throw new ArgumentNullException("resultPayParse is null!");
        return resultPayParse;
    }
}