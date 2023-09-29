namespace src.DataAccess;

public interface IBaseRepository
{
    public Task<IList<Payment>> GetPaymentsInPendingAsync();
    public Task<bool> UpdateAsync();
}