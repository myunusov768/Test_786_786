using src.DataAccess;

namespace src.BusinessLigic;

public static class CheckExtension
{
    public static CheckDto CheckDtoExtension(this Check check)
    {
        ArgumentNullException.ThrowIfNull(check);
        return new CheckDto(){ Account = check.Account, Service = check.Service };
    }
    public static Check ToCheckExtension(this CheckDto check)
    {
        ArgumentNullException.ThrowIfNull(check);
        return new Check(){ Account = check.Account, Service = check.Service };
    }
}