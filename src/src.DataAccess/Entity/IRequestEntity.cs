namespace src.DataAccess;


public interface IRequestEntity : IBaseEntity
{
    public string? Action {get; set;}
    public string? Account {get; set;}
    public string? UserId {get; set;}
    public string? Hash {get; set;}
}