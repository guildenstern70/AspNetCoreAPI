/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

using AspNetCoreApi.Models;
using AspNetCoreApi.Services;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AspNetCoreApi.Test;

public class ServiceTest
{
    private readonly IPersonService _personService;
    
    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly ITestOutputHelper _output;

    public ServiceTest(ITestOutputHelper output, 
        DataContext context,
        IPersonService personService)
    {
        this._output = output;
        this._personService = personService;
        context.Database.EnsureCreated();
    }

    [Fact]
    public void DatabaseShouldExist()
    {
        File.Exists("aspnetcoreapi.db").Should().BeTrue();
    }

    [Fact]
    public void ListPersonsTest()
    {
        this._output.WriteLine("List Persons...");
        this._personService.Should().NotBeNull();
        long size = this._personService.Size();
        this._output.WriteLine("There are {0} persons", size);
        List<Person> persons = this._personService.GetAll();
        persons.Should().NotBeNull();
        persons.Count.Should().Be(unchecked((int)size));
    }
}
