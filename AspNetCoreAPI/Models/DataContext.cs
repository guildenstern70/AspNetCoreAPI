/*
 *
 * AspNetCore API Template
 * Copyright (C) 2020-25 Alessio Saltarin
 * MIT License - see LICENSE file
 *
 */

using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAPI.Models;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new DbSeeding(modelBuilder).Seed();
    }
}