/*
 *
 * AspNetCore API Template
 * Copyright (C) 2020-25 Alessio Saltarin
 * MIT License - see LICENSE file
 *
 */

namespace AspNetCoreAPI.Models;

public class Person
{
    public int PersonId { get; set; }
    public string? Name { get; init; }
    public string? Surname { get; init; }
    public int Age { get; init; }
    public string? SerialNumber { get; init; }
}