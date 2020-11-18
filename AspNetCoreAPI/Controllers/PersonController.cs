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
        private Services.PersonService service;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            this._logger = logger;
            this.service = new PersonService();
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return this.service.GetAll().AsEnumerable<Person>();
        }

        [HttpGet("bySerialNumber")]
        public Person GetBySerial([FromQuery] string serialNumber)
        {
            return this.service.GetPerson(serialNumber);
        }

        [HttpPost]
        public string Create(Person person)
        {
            var createdPerson = this.service.AddPerson(person);
            return createdPerson.SerialNumber;
        }


    }
}
