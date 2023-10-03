using Microsoft.Extensions.Logging;
using src.DataAccess;
using Microsoft.Extensions.Hosting;

namespace src.BusinessLigic;


public sealed class JobImon : BackgroundService
{
    private readonly IBaseRepository _repository;
    private readonly IProService _proService;
    private readonly AppSettings _appSettings;
    private readonly HashingMd5 _hashing;
    private readonly ILogger _logger;

    public JobImon(IBaseRepository repository, IProService proService, AppSettings appSettings, HashingMd5 hashing, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(repository);
        ArgumentNullException.ThrowIfNull(proService);
        _repository = repository;
        _proService = proService;
        _appSettings = appSettings;
        _hashing = hashing;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        while(token.IsCancellationRequested)
        {
            try
            {
                var pays = await PaysAsync(token);
                await PayAsync(pays,token);

                //long providerID, int providerErrorCode, Status status, CancellationToken token = default
                var re = await _repository.GetPaymentsForCheckAsync(int.Parse(_appSettings.Services["1841"]), 2, Status.Pending, token);
                await CheckStatusAsync(re,token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }
    }
    private async Task<IList<Pay>> PaysAsync(CancellationToken token = default)
    {
        var payments = await _repository.GetPaymentsInPendingAsync(Status.Pending, token);
        var pays = new List<Pay>();
        var service = _appSettings.Services["2560"];
        var userId = _appSettings.UserId;
        foreach(var payment in payments)
        {
            var hashing = _hashing.GetHashPay(payment.Number,payment.PaySum);
            var pay = new Pay()
            { 
                Account = payment.Number, 
                Action = _appSettings.Actions["pay"], 
                Amount = payment.PaySum, 
                PhoneNumber = payment.Number, 
                Service = service, 
                UserId = userId, 
                TrnDateTime = payment.RegDateTime.ToString(), 
                TxnId = payment.PaymentID.ToString(), 
                Hash = hashing
            };
            pays.Add(pay);
        }
        return pays;
    }
    private async Task<ResultPay> PayAsync(Pay pay)
    {
        return await _proService.Pay(pay);
        //вакти providerPaymantId = pay
    }
    private async Task PayAsync(IList<Pay> pays, CancellationToken token = default)
    {   
        foreach(var pay in pays)
        {
            var re = await PayAsync(pay);
            
            if(re.Code == 7)
            {
                var result = await CheckStatusAcync(pay);
                if(result.Code == 2)
                {
                    await _repository.UpdateAsync(result.PaymentId, result, Status.Pending, token);
                }
                if(result.Code == 1)
                {
                    await _repository.UpdateAsync(result.PaymentId, result, Status.Success, token);
                }
            }
        }
        
    }
    //Check status for paymants
    private async Task CheckStatusAsync(IList<Payment> payments, CancellationToken token = default)
    {   
        foreach(var payment in payments)
        {
            var result = await CheckStatusAcync(payment);
            if(result.Code == 1)
            {
                await _repository.UpdateAsync(result.PaymentId, result, Status.Success, token);
            }
        }
        
    }
    private async Task<ResultCheckStatus> CheckStatusAcync(Pay pay, CancellationToken token = default)
    {
        var hashing = _hashing.GetHashCheckStatus(pay.Account);
        var checkStatus = new CheckStatus(){ Account = pay.Account, Action = _appSettings.Actions["checkStatus"], Id = pay.TxnId, UserId = pay.UserId, Hash = hashing};
        return await _proService.CheckStatus(checkStatus);
    }
    private async Task<ResultCheckStatus> CheckStatusAcync(Payment paymant, CancellationToken token = default)
    {
        var hashing = _hashing.GetHashCheckStatus(paymant.Number);
        var checkStatus = new CheckStatus(){ Account = paymant.Number, Action = _appSettings.Actions["checkStatus"], Id = paymant.OuterPayID.ToString(), UserId = _appSettings.UserId, Hash = hashing};
        return await _proService.CheckStatus(checkStatus);
    }
    
}