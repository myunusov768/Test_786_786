namespace src.DataAccess;

public sealed record CheckDto : IBaseDto
{
    public string? Service {get; set;}
    public string? Account {get; set;}
}