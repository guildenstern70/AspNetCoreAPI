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
    }
}