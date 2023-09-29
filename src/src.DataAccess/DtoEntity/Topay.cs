namespace src.DataAccess;

public sealed record Topay : IBaseDto
{
    public string id { get; set; }
    public string info { get; set; }
}
