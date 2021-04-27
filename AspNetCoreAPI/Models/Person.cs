﻿/*
 * 
 * AspNetCore API Template
 * (C) 2020-21 Alessio Saltarin
 * MIT LICENSE
 * 
 */

namespace AspNetCoreAPI.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public int Age { get; init; }
        public string SerialNumber { get; init; }

    }
}
