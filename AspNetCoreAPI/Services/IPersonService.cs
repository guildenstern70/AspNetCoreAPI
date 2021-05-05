/*
 * 
 * AspNetCore API Template
 * (C) 2020-21 Alessio Saltarin
 * MIT LICENSE
 * 
 */

using System.Collections.Generic;
using AspNetCoreAPI.Models;

namespace AspNetCoreAPI.Services
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Person AddPerson(Person p);
        long Size();
        Person GetPerson(int id);
        void DeletePerson(int id);
    }
}