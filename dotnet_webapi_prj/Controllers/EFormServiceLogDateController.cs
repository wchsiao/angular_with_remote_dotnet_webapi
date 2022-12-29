using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace angular_remote_webapi_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class EFormServiceLogDateController : ControllerBase
{
    private readonly ILogger<EFormServiceLogDateController> _logger;

    public EFormServiceLogDateController(ILogger<EFormServiceLogDateController> logger)
    {
        _logger = logger;
    }

    [EnableCors("Policy1")]
    [HttpGet(Name = "GetEFormServiceLogDate")]
    public IEnumerable<EFormServiceLogDate> Get()
    {
        return EFormServiceData.GetEFormServiceLogDate();
    }
}
