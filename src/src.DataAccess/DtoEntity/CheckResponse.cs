namespace src.DataAccess;

public sealed record CheckResponse : IBaseDto
{
    public int code { get; set; }
    public string description { get; set; }
    public decimal commis { get; set; }
    public List<Additionals> fields { get; set; }
    public List<Topay> choice { get; set; }
    public object prv_answer { get; set; }
}
