namespace src.DataAccess;

public sealed record Check : IRequestEntity
{
    public string? Service {get; set;}
    public string? Action {get; set;}
    public string? Account {get; set;}
    public string? UserId {get; set;}
    public string? Hash {get; set;}
}