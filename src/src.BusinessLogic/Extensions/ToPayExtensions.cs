

using src.DataAccess;

namespace src.BusinessLigic;

public static class ToPayExtensions
{
    public static Topay ToPayExtension(this ToPay? toPay)
    {
        return new Topay(){ id = toPay.Account, info = toPay.ProductName};
    }
    public static List<Topay> ToPayExtension(this List<ToPay> toPay)
    {
        var toPays = new List<Topay>();
        foreach(var item in toPay)
        {
            toPays.Add(item.ToPayExtension());
        }
        return toPays;
    }
}