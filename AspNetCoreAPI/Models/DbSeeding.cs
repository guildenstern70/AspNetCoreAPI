/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApi.Models;

public class DbSeeding
{
    private readonly ModelBuilder _modelBuilder;
    
    public DbSeeding(ModelBuilder mb)
    {
        this._modelBuilder = mb;
    }

    public void Seed()
    {
        this.CreatePersons();
    }

    private void CreatePersons()
    {
        var persons = new[]
        {
            new Person { PersonId = 1001, Name = "Alessio", Surname = "Saltarin", Age = 47, SerialNumber = "1" },
            new Person { PersonId = 1002, Name = "Elena", Surname = "Zambrelli", Age = 27, SerialNumber = "2" },
            new Person { PersonId = 1003, Name = "Giovanni", Surname = "Rossi", Age = 43, SerialNumber = "3" },
            new Person { PersonId = 1004, Name = "Mauro", Surname = "Sangiovanni", Age = 21, SerialNumber = "4" }
        };
        this._modelBuilder.Entity<Person>().HasData(persons);
    }
    
}