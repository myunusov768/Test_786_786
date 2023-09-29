using Microsoft.AspNetCore.Mvc;
using src.BusinessLigic;
using src.DataAccess;

namespace src.Presentation;

[ApiController]
[Route("imon/check")]
public sealed class CheckController : ControllerBase
{
    
    private readonly ISheckService _service;
    private readonly ILogger _logger;

    public CheckController(ISheckService service, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(service);
        ArgumentNullException.ThrowIfNull(logger);
        _service = service;
        _logger = logger;
    }
    [HttpPost]
    public async Task<IActionResult> CheckResponseAsync([FromBody]CheckDto check, CancellationToken token = default)
    {
        var result = await _service.CheckAccountAsync(check,token);
        try
        {
            return Ok(result);
        }
        catch(Exception ex)
        {
            _logger.LogDebug(ex.Message);
            return BadRequest(check);
        }
    }
    
}