


using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using NLog;

namespace src.DataAccess;

public sealed class CheckInfrastructure : ICheckInfrastructure
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly HttpClient _httpClient;
    private readonly AppSettings _appSettings;
    private readonly JsonSerializerOptions jsonSerializerOptions;

    public CheckInfrastructure(HttpClient httpClient, AppSettings appSettings, JsonSerializerOptions jsonSerializerOptions)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(appSettings);
        _httpClient = httpClient;
        _appSettings = appSettings;
        this.jsonSerializerOptions = jsonSerializerOptions;
    }

    public async Task<ResultChack> CheckAccount(Check check, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(check);
        _logger.Debug($"Request to {_appSettings.Url} to Action {check.Account}: {JsonSerializer.Deserialize<Check>(check.ToString(),jsonSerializerOptions)}");
        var result = await _httpClient.PostAsJsonAsync(_appSettings.Url, check,jsonSerializerOptions, token);
        if(result.IsSuccessStatusCode)
        {
            var f = await result.Content.ReadFromJsonAsync<ResultChack>(jsonSerializerOptions,token);
            _logger.Debug($"Result to {_appSettings.Url} in Action {check.Account}: {result.Content}");
            if(f is not null)
                return f;
        }
        _logger.Debug($"Eror result to {_appSettings.Url} in Action {check.Account}: {result.Content}");

        return new ResultChack();
    }
}