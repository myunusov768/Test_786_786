


using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using NLog;

namespace src.DataAccess;

public sealed class Infrastructure : IInfrastructure
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly HttpClient _httpClient;
    private readonly AppSettings _appSettings;
    private readonly JsonSerializerOptions jsonSerializerOptions;

    public Infrastructure(HttpClient httpClient, AppSettings appSettings, JsonSerializerOptions jsonSerializerOptions)
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
        _logger.Debug($"Request to {_appSettings.Url} to Action {_appSettings.Actions}: {JsonSerializer.Deserialize<Check>(check.ToString(),jsonSerializerOptions)}");
        var result = await _httpClient.PostAsJsonAsync(_appSettings.Url, check,jsonSerializerOptions, token);
        if(result.IsSuccessStatusCode)
        {
            var f = await result.Content.ReadFromJsonAsync<ResultChack>(jsonSerializerOptions,token);
            _logger.Debug($"Result to {_appSettings.Url} in Action {_appSettings.Actions}: {result.Content}");
            if(f is not null)
                return f;
        }
        _logger.Debug($"Eror result to {_appSettings.Url} in Action {_appSettings.Actions}: {result.Content}");

        return new ResultChack();
    }

    public async Task<ResultCheckStatus> CheckStatus(CheckStatus checkStatus, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(checkStatus);
        _logger.Debug($"Request to {_appSettings.Url} to Action {_appSettings.Actions}: {JsonSerializer.Deserialize<ResultCheckStatus>(checkStatus.ToString(),jsonSerializerOptions)}");
        var result = await _httpClient.PostAsJsonAsync(_appSettings.Url,checkStatus,jsonSerializerOptions,token);
        if(result.IsSuccessStatusCode)
        {
            var f = await result.Content.ReadFromJsonAsync<ResultCheckStatus>(jsonSerializerOptions,token);
            _logger.Debug($"Result to {_appSettings.Url} in Action {_appSettings.Actions}: {result.Content}");
            if(f is not null)
                return f;
        }
        _logger.Debug($"Eror result to {_appSettings.Url} in Action {_appSettings.Actions}: {result.Content}");

        return new ResultCheckStatus();
    }

    public async Task<ResultPay> Pay(Pay pay, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(pay);
        _logger.Debug($"Request to {_appSettings.Url} to Action {_appSettings.Actions}: {JsonSerializer.Deserialize<ResultPay>(pay.ToString(),jsonSerializerOptions)}");
        var result = await _httpClient.PostAsJsonAsync(_appSettings.Url, pay, jsonSerializerOptions, token);
        if(result.IsSuccessStatusCode)
        {
            var f = await result.Content.ReadFromJsonAsync<ResultPay>( jsonSerializerOptions, token );
            _logger.Debug($"Result to {_appSettings.Url} in Action {_appSettings.Actions}: {result.Content}");
            if(f is not null)
                return f;
        }
        _logger.Debug($"Eror result to {_appSettings.Url} in Action {_appSettings.Actions}: {result.Content}");

        return new ResultPay();
    }
}