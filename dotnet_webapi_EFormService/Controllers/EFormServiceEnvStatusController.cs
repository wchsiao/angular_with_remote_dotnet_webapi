using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using dotnet_webapi_EFormService.Models.EFormService;

namespace dotnet_webapi_EFormService.Controllers;

[ApiController]
[Route("[controller]")]
public class EFormServiceEnvStatusController : ControllerBase
{
    private readonly ILogger<EFormServiceEnvStatusController> _logger;

    public EFormServiceEnvStatusController(ILogger<EFormServiceEnvStatusController> logger)
    {
        _logger = logger;
    }

    [EnableCors("PolicyCors")]
    [HttpGet(Name = "GetEFormServiceEnvStatus")]
    public IEnumerable<EFormServiceEnvStatus> Get()
    {
        return EFormServiceData.GetEFormServiceEnvStatuses();
    }
}