
namespace src.DataAccess;

public sealed record CheckStatus : IRequestEntity
{
    public string? Action { get; set; }
    public string? Account { get; set; }
    public string? UserId { get; set; }
    public string? Hash { get; set; }
    public long Id { get; set; }
}