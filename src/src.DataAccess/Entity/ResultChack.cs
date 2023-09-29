namespace src.DataAccess;

public sealed record ResultChack : IResultEntity
{
    public int Code {get; set;}
    public string? Message {get; set;}
    public List<ToPay>? ToPay { get; set; }
}
