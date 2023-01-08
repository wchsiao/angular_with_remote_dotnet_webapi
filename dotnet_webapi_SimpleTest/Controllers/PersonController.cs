using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace dotnet_webapi_SimpleTest.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [EnableCors("PolicyCors")]
    [HttpGet(Name = "Persons")]
    public IEnumerable<Person> Get()
    {
        return SimpleTestData.GetPersons();
    }

    [EnableCors("PolicyCors")]
    [HttpGet("{id}")]
    public Person? Get(int id)
    {
        return SimpleTestData.GetPerson(id);
    }
     
    [EnableCors("PolicyCors")]
    [HttpPost()]
    public int Post(Person person)
    {
        return SimpleTestData.AddPerson(person);
    }

    [EnableCors("PolicyCors")]
    [HttpPut("{id}")]
    public int Put(int id, Person person)
    {
        return SimpleTestData.UpdatePerson(id, person);
    }

    [EnableCors("PolicyCors")]
    [HttpDelete("{id}")]
    public int Delete(int id)
    {
        return SimpleTestData.DeletePerson(id);
    }
}
