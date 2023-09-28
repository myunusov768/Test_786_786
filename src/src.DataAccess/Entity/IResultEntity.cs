namespace src.DataAccess;


public interface IResultEntity : IBaseEntity
{
    public int Code {get; set;}
    public string? Message {get; set;}
}