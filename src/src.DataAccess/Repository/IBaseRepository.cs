namespace src.DataAccess;

public interface IBaseRepository
{
    public Task<IList<Payment>> GetPaymentsInPendingAsync(Status status, CancellationToken token = default);
    public Task<IList<Payment>> GetPaymentsForCheckAsync(long providerID, int providerErrorCode, Status status, CancellationToken token = default);
    public Task<bool> UpdateAsync(IList<Payment> payments, CancellationToken token = default);
    public Task<IList<ErrorCode>> GetErorCodeAsync(CancellationToken token = default);
    public Task<bool> UpdateAsync(long paymantId, ResultCheckStatus resultCheckStatus, Status status , CancellationToken token = default);
}