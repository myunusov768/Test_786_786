namespace src.DataAccess;


public sealed record ToPay : IBaseEntity
{
    public string? Account {get; set;}
    public string? ProductName {get; set;}
}