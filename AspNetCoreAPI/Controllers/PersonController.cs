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

namespace AspNetCoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger,
                               IPersonService personService)
        {
            this._logger = logger;
            this._personService = personService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
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
            return Ok(this._personService.Size());
        }

        [HttpGet("byId")]
        public ActionResult<Person> GetBySerial([FromQuery] int id)
        {
            var person =  this._personService.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public ActionResult<string> Create(Person person)
        {
            var createdPerson = this._personService.AddPerson(person);
            if (createdPerson == null)
            {
                return BadRequest();
            }
            return Ok(createdPerson.SerialNumber);
        }


    }
}
