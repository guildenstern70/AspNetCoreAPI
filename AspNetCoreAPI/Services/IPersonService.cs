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
      List<Person> GetAll();
      Person AddPerson(Person p);
      long Size();
      Person? GetPerson(int id);
      void DeletePerson(int id);
}