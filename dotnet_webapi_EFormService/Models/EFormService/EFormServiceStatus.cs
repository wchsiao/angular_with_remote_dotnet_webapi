namespace dotnet_webapi_EFormService.Models.EFormService;

public class EFormServiceStatus
{
    public DateTime StatusDateTime { get; internal set; }

    public string? ServerName { get; set; }

    public int Success { get; set; }

    public int Failed { get; set; }
}
