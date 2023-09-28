namespace src.DataAccess;

public sealed record ResultCheckStatus : IResultEntity
{
    public int Code {get; set;}
    public string? Message {get; set;}

    public long PaymentId { get; set; }
    public DateTime Datetime { get; set; }
}