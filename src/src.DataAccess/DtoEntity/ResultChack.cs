namespace src.DataAccess;

public sealed record ResultChackDto : IBaseDto
{
    public int Code {get; set;}
    public string? Message {get; set;}
    public ToPay? ToPay { get; set; }
}
