

namespace src.DataAccess;


public interface ICheckInfrastructure
{
    public Task<string> CheckAccountAsync(Check chack, CancellationToken token = default);
}