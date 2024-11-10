using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Application.Peoples.Commands.UpdatePeople;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Peoples.Commands;

public class UpdatePeopleTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreNull()
    {
        // Arrange
        var command = new UpdatePeopleCommand
        {
            Id = null,
            Name = null,
            BirthYear = null,
            Gender = null,
            HomeworldId = null,
            ConcurrencyStamp = null
        };

        // Act
        var response = await TestFixture.UpdatePeopleAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(6);
    }

    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreEmptyOrDontExistInDb()
    {
        // Arrange
        var command = new UpdatePeopleCommand
        {
            Id = Guid.Empty,
            Name = string.Empty,
            BirthYear = string.Empty,
            Gender = string.Empty,
            HomeworldId = Guid.NewGuid(),
            ConcurrencyStamp = string.Empty
        };

        // Act
        var response = await TestFixture.UpdatePeopleAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(6);
    }

    [Fact]
    public async Task Should_ReturnSuccess_When_AllFieldsAreValid()
    {
        // Arrange
        var planet = new Planet
        {
            Name = "Name",
            Gravity = "Gravity",
            Climate = "Climate"
        };

        DbContext.Planets.Add(planet);
        await DbContext.SaveChangesAsync();

        var people = new People
        {
            Name = "Name",
            BirthYear = "BirthYear",
            Gender = "Gender",
            HomeworldId = planet.Id
        };

        DbContext.Peoples.Add(people);
        await DbContext.SaveChangesAsync();

        var command = new UpdatePeopleCommand
        {
            Id = people.Id,
            Name = "Name2",
            BirthYear = "BirthYear2",
            Gender = "Gender2",
            HomeworldId = planet.Id,
            ConcurrencyStamp = people.ConcurrencyStamp
        };

        // Act
        var response = await TestFixture.UpdatePeopleAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}
