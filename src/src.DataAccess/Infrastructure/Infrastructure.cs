


using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;

namespace src.DataAccess;

public sealed class Infrastructure : IInfrastructure
{
    private readonly HttpClient _httpClient;
    private readonly AppSettings _appSettings;
    private readonly ILogger _logger;

    public Infrastructure(HttpClient httpClient, AppSettings appSettings, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(appSettings);
        _httpClient = httpClient;
        _appSettings = appSettings;
        _logger = logger;
    }
    public async Task<string> CheckStatusAsync(CheckStatus checkStatus, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(checkStatus);
        var content = JsonContent.Create(JsonSerializer.Serialize(checkStatus, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true }));
        _logger.LogDebug($"CheckStatus action request : {JsonSerializer.Serialize(checkStatus, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true })}");
        var httpResponseMessage = await _httpClient.PostAsync(_appSettings.Url, content, token);
        _logger.LogDebug($"CheckStatus action result : {JsonSerializer.Serialize(httpResponseMessage.Content, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true })}");
        if(httpResponseMessage.IsSuccessStatusCode)
        {
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        return string.Empty;
        
    }

    public async Task<string> PayAsync(Pay pay, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(pay);
        var content = JsonContent.Create(JsonSerializer.Serialize(pay, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true }));
        _logger.LogDebug($"Pay action request : {JsonSerializer.Serialize(pay, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true })}");
        var httpResponseMessage = await _httpClient.PostAsync(_appSettings.Url, content, token);
        _logger.LogDebug($"Pay action result : {JsonSerializer.Serialize(httpResponseMessage.Content, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true })}");
        if(httpResponseMessage.IsSuccessStatusCode)
        {
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        return string.Empty;
        
    }
}