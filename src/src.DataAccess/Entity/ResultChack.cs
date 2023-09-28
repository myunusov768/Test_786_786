namespace src.DataAccess;

public sealed record ResultChack : IResultEntity
{
    public int Code {get; set;}
    public string? Message {get; set;}
    public ToPay? ToPay { get; set; }
}
