

namespace src.DataAccess;


public interface ICheckInfrastructure
{
    public Task<ResultChack> CheckAccount(Check chack, CancellationToken token = default);
}