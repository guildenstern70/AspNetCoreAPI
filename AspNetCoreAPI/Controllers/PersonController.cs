/**
 * 
 * AspNetCore API Template
 * (C) 2020 Alessio Saltarin
 * MIT LICENSE
 * 
 **/

using AspNetCoreAPI.Models;
using AspNetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly Services.PersonService _service;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            this._logger = logger;
            this._service = new PersonService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            var result = this.service.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

                    

        [HttpGet("count")]
        public ActionResult<long> Size()
        {
            return Ok(this.service.Size());
        }

        [HttpGet("bySerialNumber")]
        public ActionResult<Person> GetBySerial([FromQuery] string serialNumber)
        {
            var person =  this.service.GetPerson(serialNumber);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public ActionResult<string> Create(Person person)
        {
            var createdPerson = this.service.AddPerson(person);
            if (createdPerson == null)
            {
                return BadRequest();
            }
            return Ok(createdPerson.SerialNumber);
        }


    }
}
