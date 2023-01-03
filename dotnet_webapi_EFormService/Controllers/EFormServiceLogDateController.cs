using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using dotnet_webapi_EFormService.Models.EFormService;

namespace dotnet_webapi_EFormService.Controllers;

[ApiController]
[Route("[controller]")]
public class EFormServiceLogDateController : ControllerBase
{
    private readonly ILogger<EFormServiceLogDateController> _logger;

    public EFormServiceLogDateController(ILogger<EFormServiceLogDateController> logger)
    {
        _logger = logger;
    }

    [EnableCors("PolicyCors")]
    [HttpGet(Name = "GetEFormServiceLogDate")]
    public IEnumerable<EFormServiceLogDate> Get()
    {
        return EFormServiceData.GetEFormServiceLogDate();
    }
}
