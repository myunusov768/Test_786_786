
namespace src.DataAccess;

public sealed class BaseRepository : IBaseRepository
{
    private readonly OsonDbContex _osonDbContex;
    private readonly AppSettings _appSettings;

    public BaseRepository(OsonDbContex osonDbContex,AppSettings appSettings)
    {
        ArgumentNullException.ThrowIfNull(osonDbContex);
        _osonDbContex = osonDbContex;
        _appSettings = appSettings;
    }

    public Task<IList<Payment>> GetPaymentsInPendingAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync()
    {
        throw new NotImplementedException();
    }
}