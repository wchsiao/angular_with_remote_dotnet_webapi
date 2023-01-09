using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using dotnet_webapi_EFormService.Models.EFormService;

namespace dotnet_webapi_EFormService.Controllers;

[ApiController]
[Route("[controller]")]
public class EFormServiceRequestTypeStatusController : ControllerBase
{
    private readonly ILogger<EFormServiceStatusController> _logger;

    public EFormServiceRequestTypeStatusController(ILogger<EFormServiceStatusController> logger)
    {
        _logger = logger;
    }

    [EnableCors("PolicyCors")]
    [HttpGet(Name = "GetEFormServiceRequestTypeStatus")]
    public IEnumerable<EFormServiceRequestTypeStatus> Get(string id)
    {
        var servername = id;
        return EFormServiceData.GetEFormServiceRequestTypeStatus(servername);
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
