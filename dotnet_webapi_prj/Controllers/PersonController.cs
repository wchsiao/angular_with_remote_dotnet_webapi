using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace dotnet_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [EnableCors("Policy1")]
    [HttpGet(Name = "Persons")]
    public IEnumerable<Person> Get()
    {
        return TheData.GetPersons();
    }
}
