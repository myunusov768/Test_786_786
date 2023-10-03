
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace src.DataAccess;

public sealed partial class BaseRepository : IBaseRepository
{
    private readonly OsonDbContex _osonDbContex;
    private readonly AppSettings _appSettings;
    private readonly ILogger logger;

    public BaseRepository(OsonDbContex osonDbContex,AppSettings appSettings, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(osonDbContex);
        _osonDbContex = osonDbContex;
        _appSettings = appSettings;
        this.logger = logger;
    }

    public async Task<IList<ErrorCode>> GetErorCodeAsync(CancellationToken token = default)
    {
        //Akoi Adab!!
        return await _osonDbContex.ErrorCodes.Where(x=>_appSettings.Services.Select(x=>x.Key).Contains(x.ProviderID.ToString())).ToListAsync(token);
    }

    public async Task<IList<Payment>> GetPaymentsForCheckAsync(long providerID, int providerErrorCode, Status status, CancellationToken token = default)
    {
        return await _osonDbContex.Payments.Where(x=>x.Status == (int)status && x.ProviderID == providerID && x.ProviderErrorCode == providerErrorCode.ToString()).ToListAsync(token);
    }

    public async Task<IList<Payment>> GetPaymentsInPendingAsync( Status status, CancellationToken token = default )
    {
        ArgumentNullException.ThrowIfNull(status);
        //Получение сервис Id от партнера 
        var agentServiceId = _appSettings.Services["1"];
        //Получение транзакции которые в ожидании стоят
        return await _osonDbContex.Payments.Where(x=> x.Status == (uint)status && x.AgentID.ToString() == agentServiceId).ToListAsync();
        
    }

    public async Task<bool> UpdateAsync(IList<Payment> payments, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(payments);
        foreach(var paymant in payments)
            _osonDbContex.Payments.Update(paymant);
        
        var result = await _osonDbContex.SaveChangesAsync(token);
        return result > 0;
    }
    public async Task<bool> UpdateAsync(long paymantId, ResultCheckStatus resultCheckStatus, Status status, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(paymantId);
        
        var getPaymant = await _osonDbContex.Payments.FirstOrDefaultAsync(X=>X.PaymentID == paymantId);
        if(getPaymant is null)
            return false;
        getPaymant.Status = (int)status;
        getPaymant.ProviderErrorCode = resultCheckStatus.Code.ToString();
        getPaymant.OuterPayID = resultCheckStatus.PaymentId;
        var result = await _osonDbContex.SaveChangesAsync(token);
        return result > 0;
    }
}