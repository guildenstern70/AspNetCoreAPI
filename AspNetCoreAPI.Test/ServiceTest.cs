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
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace AspNetCoreApi.Test;

public class ServiceTest: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly ITestOutputHelper _output;
    private readonly WebApplicationFactory<Program> _factory;
    
    public ServiceTest(ITestOutputHelper output,
        WebApplicationFactory<Program> factory)
    {
        this._output = output;
        this._factory = factory;
        this._output.WriteLine("Running tests in " + Directory.GetCurrentDirectory());
    }

    [Fact]
    public void DatabaseShouldExist()
    {
        var client = _factory.CreateClient();
        File.Exists("aspnetcoreapi.db").Should().BeTrue();
    }

    [Fact]
    public async Task ListPersonsTest()
    {
        // Arrange
        using var scope = _factory.Services.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var personService = scopedServices.GetRequiredService<IPersonService>();
        this._output.WriteLine("List Persons...");
        personService.Should().NotBeNull();
        var size = await personService.Size();
        this._output.WriteLine("There are {0} persons", size);
        var persons = await personService.GetAll();
        persons.Should().NotBeNull();
        persons.Count.Should().Be(unchecked((int)size));
    }
}
