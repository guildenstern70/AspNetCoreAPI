/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

using AspNetCoreApi.Models;
using AspNetCoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonService personService,
        ILogger<PersonController> logger)
    {
        this._logger = logger;
        this._personService = personService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Person>> Get()
    {
        _logger.LogInformation("GET api/person");
        List<Person> result = this._personService.GetAll();
        return Ok(result);
    }
        
    [HttpGet("count")]
    public ActionResult<long> Size()
    {
        _logger.LogInformation("api/count");
        return Ok(this._personService.Size());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Person> GetBySerial(int id)
    {
        _logger.LogInformation("GET api/person/{Id}", id);
        var person =  this._personService.GetPerson(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteById(int id)
    {
        _logger.LogInformation("DELETE api/persona/{Id}", id);
        this._personService.DeletePerson(id);
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<Person> Create([FromBody] Person person)
    {
        _logger.LogInformation("POST api/person");
        Person createdPerson = this._personService.AddPerson(person);
        return this.CreatedAtAction(
            nameof(this.Get), new { id = createdPerson.PersonId }, createdPerson);
    }
}