


using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace src.DataAccess;

public sealed class CheckInfrastructure : ICheckInfrastructure
{
    // private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    private readonly HttpClient _httpClient;
    private readonly AppSettings _appSettings;
    private readonly ILogger _logger;

    public CheckInfrastructure(HttpClient httpClient, AppSettings appSettings, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(appSettings);
        _httpClient = httpClient;
        _appSettings = appSettings;
        _logger = logger;
    }

    public async Task<string> CheckAccountAsync(Check check, CancellationToken token = default)
    {
        var content = JsonContent.Create(JsonSerializer.Serialize(check, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true }));
        _logger.LogDebug($"Check action request : {JsonSerializer.Serialize(check, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true })}");
        var httpResponseMessage = await _httpClient.PostAsync(_appSettings.Url, content, token);
        _logger.LogDebug($"Check action result : {JsonSerializer.Serialize(httpResponseMessage.Content, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true })}");
        if(httpResponseMessage.IsSuccessStatusCode)
        {
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        return string.Empty;
    }
}