namespace src.DataAccess;

public sealed record Pay : IRequestEntity
{
    /// <summary>
    /// Сервис нужно получить из конфигурации
    /// </summary>
    /// <value></value>
    public string? Service { get; set; }
    public string? Action { get; set; } = "";
    /// <summary>
    /// Number in Oson Data Payment Table
    /// </summary>
    /// <value></value>
    public string? Account { get; set; }
    public string? UserId { get; set; }
    public string? Hash { get; set; }
    /// <summary>
    /// ProviderSum in Oson Data Payment Table
    /// </summary>
    /// <value></value>
    public decimal Amount { get; set; }
    /// <summary>
    /// Нужно спросит от Имона
    /// </summary>
    /// <value></value>
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// RegDateTime in Oson Data Payment Table
    /// </summary>
    /// <value></value>
    public string? TrnDateTime { get; set; }
    /// <summary>
    /// PaymantId in Oson Data Payment Table
    /// </summary>
    /// <value></value>
    public string? TxnId { get; set; }
}