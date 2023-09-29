using Microsoft.AspNetCore.Mvc;
using NLog;
using src.BusinessLigic;
using src.DataAccess;

namespace src.Presentation;

[ApiController]
[Route("imon/check")]
public sealed class CheckController : ControllerBase
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    private readonly ISheckService _service;

    public CheckController(ISheckService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<CheckResponse> CheckResponseAsync([FromBody]CheckDto check, CancellationToken token = default)
    {
        return  await _service.CheckAccount(check,token);
    }
    
}