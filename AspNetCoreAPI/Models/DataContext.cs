/*
 *
 * AspNetCore API Template
 * Copyright (C) 2020-25 Alessio Saltarin
 * MIT License - see LICENSE file
 *
 */

namespace AspNetCoreAPI.Models;

using Microsoft.EntityFrameworkCore;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new DbSeeding(modelBuilder).Seed();
    }
}