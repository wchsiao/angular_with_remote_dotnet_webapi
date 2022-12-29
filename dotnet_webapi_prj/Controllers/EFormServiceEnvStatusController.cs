using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace angular_remote_webapi_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class EFormServiceEnvStatusController : ControllerBase
{
    private readonly ILogger<EFormServiceEnvStatusController> _logger;

    public EFormServiceEnvStatusController(ILogger<EFormServiceEnvStatusController> logger)
    {
        _logger = logger;
    }

    [EnableCors("Policy1")]
    [HttpGet(Name = "GetEFormServiceEnvStatus")]
    public IEnumerable<EFormServiceEnvStatus> Get()
    {
        return EFormServiceData.GetEFormServiceEnvStatuses();
    }
}
