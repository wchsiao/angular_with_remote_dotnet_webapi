namespace dotnet_webapi_EFormService.Models.EFormService;

public class EFormServiceEnvStatus
{
    public DateTime StatusDateTime { get; set; }

    public List<EFormServiceStatus>? EFormServiceStatusList { get; set; }
}
