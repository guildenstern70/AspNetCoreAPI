/*
 * 
 * AspNetCore API Template
 * (C) 2020-21 Alessio Saltarin
 * MIT LICENSE
 * 
 */

using System.Collections.Generic;
using System.Linq;
using AspNetCoreAPI.Models;
using Microsoft.Extensions.Logging;

namespace AspNetCoreAPI.Services
{
    public class PersonService: IPersonService
    {
        private readonly ILogger<PersonService> _logger;
        private readonly PersonContext _personContext;
        
        public PersonService(ILogger<PersonService> logger,
                             PersonContext personContext)
        {
            this._logger = logger;
            this._personContext = personContext;
            this.Initialize();
        }

        public List<Person> GetAll()
        {
            return this._personContext.Persons.ToList();
        }

        public Person AddPerson(Person p)
        {
            this._personContext.Add(p);
            this._personContext.SaveChanges();
            return p;
        }

        public long Size()
        {
            return this._personContext.Persons.Count();
        }

        public Person GetPerson(int id)
        {
            return this._personContext.Persons.Find(id);
        }

        private void Initialize()
        {
            if (!this._personContext.Persons.Any())
            {
                this._logger.LogInformation("Initializing database...");
                this._personContext.Add(new Person { Name = "Alessio", Surname = "Saltarin", Age = 47, SerialNumber = "1" });
                this._personContext.Add(new Person { Name = "Elena", Surname = "Zambrelli", Age = 27, SerialNumber = "2" });
                this._personContext.Add(new Person { Name = "Giovanni", Surname = "Rossi", Age = 43, SerialNumber = "3" });
                this._personContext.Add(new Person { Name = "Mauro", Surname = "Sangiovanni", Age = 21, SerialNumber = "4" });
                this._personContext.SaveChanges();
                this._logger.LogInformation("Done");
            }
        }

    }
}
