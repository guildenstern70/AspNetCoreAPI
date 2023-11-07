/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

using AspNetCoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public Task<List<Person>> GetAll()
        {
            this._logger.LogInformation("Getting all persons from DB");
            return this._dbContext.Persons.ToListAsync();
        }

        public async Task<Person> AddPerson(Person p)
        {
            this._logger.LogInformation("Adding one person to DB");
            this._dbContext.Add(p);
            await this._dbContext.SaveChangesAsync();
            return p;
        }

        public async Task<Person?> EditPerson(Person p)
        {
            this._logger.LogInformation("Modifying existing person to DB");
            this._dbContext.Entry(p).State = EntityState.Modified;
            
            var person = await this._dbContext.Persons.FindAsync(p.PersonId);
            if (person == null)
            {
                this._logger.LogError("Cannot find person with ID = " + p.PersonId);
                return null;
            }

            try
            {
                await this._dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                this._logger.LogError(exception.Message);
                return null;
            }

            return p;
        }

        public async Task DeletePerson(int id)
        {
            this._logger.LogInformation("Deleting person from DB");
            var person = this._dbContext.Persons.Find(id);
            if (person != null)
            {
                this._dbContext.Remove(person);
                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> Size()
        {
            return await this._dbContext.Persons.CountAsync();
        }

        public async Task<Person?> GetPerson(int id)
        {
            return await this._dbContext.Persons.FindAsync(id);
        }

}