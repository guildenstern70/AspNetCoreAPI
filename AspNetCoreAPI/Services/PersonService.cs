/*
 *
 * AspNetCore API Template
 * Copyright (C) 2020-26 Alessio Saltarin
 * MIT License - see LICENSE file
 *
 */

using AspNetCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAPI.Services;

public class PersonService(
    ILogger<PersonService> logger,
    DataContext dbContext): IPersonService
{
    public Task<List<Person>> GetAll()
    {
        logger.LogInformation("Getting all persons from DB");
        return dbContext.Persons.ToListAsync();
    }

    public async Task<Person> AddPerson(Person p)
    {
        logger.LogInformation("Adding one person to DB");
        dbContext.Add(p);
        await dbContext.SaveChangesAsync();
        return p;
    }

    public async Task<Person?> EditPerson(Person p)
    {
        logger.LogInformation("Modifying existing person to DB");
        var person = await dbContext.Persons.FindAsync(p.PersonId);
        if (person == null)
        {
            logger.LogError("Cannot find person with ID = {PersonId}", p.PersonId);
            return null;
        }

        dbContext.Entry(person).CurrentValues.SetValues(p);

        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException exception)
        {
            logger.LogError(exception.Message);
            return null;
        }

        return person;
    }

    public async Task DeletePerson(int id)
    {
        logger.LogInformation("Deleting person from DB");
        var person = await dbContext.Persons.FindAsync(id);
        if (person != null)
        {
            dbContext.Remove(person);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<int> Size()
    {
        return await dbContext.Persons.CountAsync();
    }

    public async Task<Person?> GetPerson(int id)
    {
        return await dbContext.Persons.FindAsync(id);
    }
}