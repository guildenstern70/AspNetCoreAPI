using AspNetCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAPI.Services
{
    public class PersonService
    {
        private List<Person> people;

        public PersonService()
        {
            this.people = new List<Person>();
            this.initialize();
        }

        public List<Person> GetAll()
        {
            return this.people;
        }

        public Person AddPerson(Person p)
        {
            this.people.Add(p);
            return p;
        }

        public Person GetPerson(string serialNumber)
        {
            var person = this.people.FirstOrDefault(person => person.SerialNumber == serialNumber);
            return person;
        }

        private void initialize()
        {
            this.AddPerson(new Models.Person { Name = "Alessio", Surname = "Saltarin", Age = 47, SerialNumber = "1" });
            this.AddPerson(new Models.Person { Name = "Elena", Surname = "Zambrelli", Age = 27, SerialNumber = "2" });
            this.AddPerson(new Models.Person { Name = "Giovanni", Surname = "Rossi", Age = 37, SerialNumber = "3" });
        }

    }
}
