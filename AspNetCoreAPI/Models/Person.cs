/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

namespace AspNetCoreApi.Models;

public class Person
{
    public int PersonId { get; set; }
    public string? Name { get; init; }
    public string? Surname { get; init; }
    public int Age { get; init; }
    public string? SerialNumber { get; init; }
}


