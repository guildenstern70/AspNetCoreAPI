/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

using AspNetCoreApi.Models;

namespace AspNetCoreApi.Services;

public class PersonService: IPersonService
{
        private readonly ILogger<PersonService> _logger;
        private readonly DataContext _dbContext;
        
        public PersonService(ILogger<PersonService> logger,
            DataContext dbContext)
        {
            this._logger = logger;
            this._dbContext = dbContext;
        }

        public List<Person> GetAll()
        {
            return this._dbContext.Persons.ToList();
        }

        public Person AddPerson(Person p)
        {
            this._dbContext.Add(p);
            this._dbContext.SaveChanges();
            return p;
        }

        public void DeletePerson(int id)
        {
            Person? person = this._dbContext.Persons.Find(id);
            if (person == null) return;
            this._dbContext.Remove(person);
            this._dbContext.SaveChanges();
        }

        public long Size()
        {
            return this._dbContext.Persons.Count();
        }

        public Person? GetPerson(int id)
        {
            return this._dbContext.Persons.Find(id);
        }

}