using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Application.Peoples.Commands.DeletePeople;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Peoples.Commands;

public class DeletePeopleTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreNull()
    {
        // Arrange
        var command = new DeletePeopleCommand
        {
            Id = null,
            ConcurrencyStamp = null
        };

        // Act
        var response = await TestFixture.DeletePeopleAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(2);
    }

    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreEmptyOrNotGreaterThanZero()
    {
        // Arrange
        var command = new DeletePeopleCommand
        {
            Id = Guid.Empty,
            ConcurrencyStamp = string.Empty
        };

        // Act
        var response = await TestFixture.DeletePeopleAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(2);
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

        var command = new DeletePeopleCommand
        {
            Id = people.Id,
            ConcurrencyStamp = people.ConcurrencyStamp
        };

        // Act
        var response = await TestFixture.DeletePeopleAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}
