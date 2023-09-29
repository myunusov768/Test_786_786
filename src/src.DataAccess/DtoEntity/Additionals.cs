namespace src.DataAccess;

public sealed record Additionals : IBaseDto
{
    public string name { get; set; }
    public string description { get; set; }
    public string type { get; set; }
    public string value { get; set; }
}
