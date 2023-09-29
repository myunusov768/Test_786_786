namespace src.DataAccess;

public record ErrorCode
{
    public long Id { get; set; }
    public int Code { get; set; }
    public int ProviderErrorCode { get; set; }
    public string ErrorName { get; set; } = null!;
    public int Status { get; set; }
    public int ProviderID { get; set; }
}