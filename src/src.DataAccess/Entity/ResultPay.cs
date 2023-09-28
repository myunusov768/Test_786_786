namespace src.DataAccess;

public sealed record ResultPay : IResultEntity
{
    public int Code {get; set;}
    public string? Message {get; set;}
}