

using System.Security.Cryptography;
using System.Text;

namespace src.BusinessLigic;

public class HashingMd5
{
    private readonly AppSettings _appSettings;

    public HashingMd5(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public string GetHashChech( string account )
    {
        ArgumentNullException.ThrowIfNull(account);
        
        var userId = _appSettings.UserId.ToString();
        var service = _appSettings.Services["check"];
        var password = _appSettings.Password;

        var stringForHash = string.Concat(userId, account, service, password);

        return GetHash(stringForHash);
    }
    public string GetHashPay(string account, decimal amount)
    {
        ArgumentNullException.ThrowIfNull(account);
        ArgumentNullException.ThrowIfNull(amount);
        
        var userId = _appSettings.UserId.ToString();
        var password = _appSettings.Password;

        var stringForHash = string.Concat(userId, account, amount, password);

        return GetHash(stringForHash);
    }
    public string GetHashCheckStatus(string account)
    {
        ArgumentNullException.ThrowIfNull(account);
        
        var userId = _appSettings.UserId.ToString();
        var password = _appSettings.Password;

        var stringForHash = string.Concat(userId, account, password);

        return GetHash(stringForHash);
    }
    
    private static string GetHash(string stringForHash)
    {
        var md5Hash = MD5.Create();
        var hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(stringForHash));
        return Convert.ToBase64String(hash);
    }
}