/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

using AspNetCoreApi.Models;

namespace AspNetCoreApi.Services;

public interface IPersonService
{
      Task<List<Person>> GetAll();
      Task<Person> AddPerson(Person p);
      Task<Person?> EditPerson(Person p);
      Task<int> Size();
      Task<Person?> GetPerson(int id);
      Task DeletePerson(int id);
}