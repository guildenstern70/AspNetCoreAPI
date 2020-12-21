/**
 * 
 * AspNetCore API Template
 * (C) 2020 Alessio Saltarin
 * MIT LICENSE
 * 
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAPI.Models
{
    public class Person
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public int Age { get; init; }
        public string SerialNumber { get; init; }

    }
}
