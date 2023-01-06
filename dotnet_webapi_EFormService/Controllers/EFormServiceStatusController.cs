using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using dotnet_webapi_EFormService.Models.EFormService;

namespace dotnet_webapi_EFormService.Controllers;

[ApiController]
[Route("[controller]")]
public class EFormServiceStatusController : ControllerBase
{
    private readonly ILogger<EFormServiceStatusController> _logger;

    public EFormServiceStatusController(ILogger<EFormServiceStatusController> logger)
    {
        _logger = logger;
    }

    [EnableCors("PolicyCors")]
    [HttpGet(Name = "GetEFormServiceEnvStatus")]
    public IEnumerable<EFormServiceStatus> Get()
    {
        return EFormServiceData.GetEFormServiceEnvStatuses();
    }

    /*
    [EnableCors("PolicyCors")]
    [HttpGet(Name = "/GetLogDate")]
    public DateTime GetLogDate()
    {
        return EFormServiceData.Date;
    }

    [EnableCors("PolicyCors")]
    [HttpGet(Name = "/GetMasterLogIdMin")]
    public int GetMasterLogIdMin()
    {
        return EFormServiceData.MasterLogId_Min;
    }
    */
}
