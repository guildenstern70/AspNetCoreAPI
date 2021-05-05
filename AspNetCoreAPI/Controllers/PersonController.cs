/*
 * AspNetCore API Template
 * (C) 2020-21 Alessio Saltarin
 * MIT LICENSE
 * 
 */

using System.Collections.Generic;
using AspNetCoreAPI.Models;
using AspNetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace AspNetCoreAPI.Controllers
{
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
            var result = this._personService.GetAll();
            if (result == null)
            {
                return NotFound();
            }
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
        public ActionResult<string> Create(Person person)
        {
            _logger.LogInformation("POST api/person");
            var createdPerson = this._personService.AddPerson(person);
            if (createdPerson == null)
            {
                return BadRequest();
            }
            return Ok(createdPerson.SerialNumber);
        }
    }
}
