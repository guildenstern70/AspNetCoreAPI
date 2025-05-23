/*
 *
 * AspNetCore API Template
 * Copyright (C) 2020-25 Alessio Saltarin
 * MIT License - see LICENSE file
 *
 */

using AspNetCoreAPI.Models;

namespace AspNetCoreAPI.Services;

public interface IPersonService
{
    Task<List<Person>> GetAll();
    Task<Person> AddPerson(Person p);
    Task<Person?> EditPerson(Person p);
    Task<int> Size();
    Task<Person?> GetPerson(int id);
    Task DeletePerson(int id);
}
