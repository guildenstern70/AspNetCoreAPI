/*
 * 
 * AspNetCore API Template
 * (C) 2020 Alessio Saltarin
 * MIT LICENSE
 * 
 */

using System.Collections.Generic;
using System.Linq;
using AspNetCoreAPI.Models;

namespace AspNetCoreAPI.Services
{
    public class PersonService
    {
        private readonly List<Person> _people;

        public PersonService()
        {
            this._people = new List<Person>();
            this.initialize();
        }

        public List<Person> GetAll()
        {
            return this._people;
        }

        public Person AddPerson(Person p)
        {
            this._people.Add(p);
            return p;
        }

        public long Size()
        {
            return this._people.Count;
        }

        public Person GetPerson(string serialNumber)
        {
            var person = this._people.FirstOrDefault(person => person.SerialNumber == serialNumber);
            return person;
        }

        private void initialize()
        {
            this.AddPerson(new Person { Name = "Alessio", Surname = "Saltarin", Age = 47, SerialNumber = "1" });
            this.AddPerson(new Person { Name = "Elena", Surname = "Zambrelli", Age = 27, SerialNumber = "2" });
            this.AddPerson(new Person { Name = "Giovanni", Surname = "Rossi", Age = 43, SerialNumber = "3" });
            this.AddPerson(new Person { Name = "Mauro", Surname = "Sangiovanni", Age = 21, SerialNumber = "4" });
        }

    }
}
