/*
 *
 * AspNetCore API Template
 * Copyright (C) 2020-25 Alessio Saltarin
 * MIT License - see LICENSE file
 *
 */

using AspNetCoreAPI.Models;
using AspNetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAPI.Components.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController(
    IPersonService personService,
    ILogger<PersonController> logger)
    : ControllerBase
{
    /// <summary>
    /// Get all persons
    /// </summary>
    /// <returns>A JSON list of persons</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> Get()
    {
        logger.LogInformation("GET api/person");
        var result = await personService.GetAll();
        return Ok(result);
    }

    /// <summary>
    /// Get number of persons
    /// </summary>
    /// <returns>The number of persons in the database</returns>
    [HttpGet("count")]
    public async Task<ActionResult<int>> Size()
    {
        logger.LogInformation("api/count");
        var persons = await personService.Size();
        return Ok(persons);
    }

    /// <summary>
    /// Get person by ID
    /// </summary>
    /// <param name="id">Person ID</param>
    /// <returns>A JSON representation of the person</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Person>> GetBySerial(int id)
    {
        logger.LogInformation("GET api/person/{Id}", id);
        var person = await personService.GetPerson(id);
        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    /// <summary>
    /// Delete a person by ID
    /// </summary>
    /// <param name="id">Person ID</param>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        logger.LogInformation("DELETE api/persona/{Id}", id);
        await personService.DeletePerson(id);
        return NoContent();
    }

    /// <summary>
    /// Create a new person
    /// </summary>
    /// <param name="person">See Person object model</param>
    /// <returns>The newly created person as a JSON document</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Person>> Create([FromBody] Person person)
    {
        logger.LogInformation("POST api/person");
        var createdPerson = await personService.AddPerson(person);
        return this.CreatedAtAction(
            nameof(this.Get), new
            {
                id = createdPerson.PersonId
            }, createdPerson);
    }

    /// <summary>
    /// Modify person
    /// </summary>
    /// <param name="id">Person ID</param>
    /// <param name="person">A JSON document containing all of the person attributes. See Person object model</param>
    /// <returns>The modified person JSON document</returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Edit(int id, Person person)
    {
        if (id != person.PersonId)
        {
            return BadRequest();
        }

        var modifiedPerson = await personService.EditPerson(person);
        return Ok(modifiedPerson);
    }
}