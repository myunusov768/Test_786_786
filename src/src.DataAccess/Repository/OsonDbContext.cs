using Microsoft.EntityFrameworkCore;

namespace src.DataAccess;


public sealed class OsonDbContex : DbContext
{
    private readonly AppSettings _appSettings;

    public OsonDbContex(AppSettings appSettings)
    {
        ArgumentNullException.ThrowIfNull(appSettings);
        _appSettings = appSettings;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_appSettings.StringConnection);
    }
    public DbSet<ErrorCode> ErrorCodes { get; set; }
    public DbSet<Payment> Payments { get; set; }
}
