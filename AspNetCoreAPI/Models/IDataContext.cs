/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApi.Models;

public interface IDataContext : IDisposable
{
    DbSet<Person> Persons { get; set; }
}