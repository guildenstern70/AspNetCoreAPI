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
    public async Task<ActionResult<IEnumerable<Person>>> Get()
    {
        _logger.LogInformation("GET api/person");
        var result = await this._personService.GetAll();
        return Ok(result);
    }
        
    [HttpGet("count")]
    public async Task<ActionResult<int>> Size()
    {
        _logger.LogInformation("api/count");
        var persons = await this._personService.Size();
        return Ok(persons);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Person>> GetBySerial(int id)
    {
        _logger.LogInformation("GET api/person/{Id}", id);
        var person =  await this._personService.GetPerson(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        _logger.LogInformation("DELETE api/persona/{Id}", id);
        await this._personService.DeletePerson(id);
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Person>> Create([FromBody] Person person)
    {
        _logger.LogInformation("POST api/person");
        var createdPerson = await this._personService.AddPerson(person);
        return this.CreatedAtAction(
            nameof(this.Get), new
            {
                id = createdPerson.PersonId
            }, createdPerson);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Edit(int id, Person person)
    {
        if (id != person.PersonId)
        {
            return BadRequest();
        }
        var modifiedPerson = await this._personService.EditPerson(person);
        return Ok(modifiedPerson);
    }
}