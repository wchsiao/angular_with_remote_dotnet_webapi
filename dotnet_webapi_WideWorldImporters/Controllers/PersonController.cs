using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using dotnet_webapi_WideWorldImporters.Models.WideWorldImporters;

namespace dotnet_webapi_WideWorldImporters.Controllers;

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

    [EnableCors("PolicyCors")]
    [HttpGet(Name = "Persons")]
    public IEnumerable<Person> Get()
    {
        return WideWorldImportersData.GetPersons();
    }

    [EnableCors("PolicyCors")]
    [HttpGet("{id}")]
    public Person? Get(int id)
    {
        return WideWorldImportersData.GetPerson(id);
    }

    [EnableCors("PolicyCors")]
    [HttpPut("{id}")]
    public int Put(int id, Person person)
    {
        return WideWorldImportersData.UpdatePerson(id, person);
    }

    [EnableCors("PolicyCors")]
    [HttpDelete("{id}")]
    public int Delete(int id)
    {
        return WideWorldImportersData.DeletePerson(id);
    }
}
