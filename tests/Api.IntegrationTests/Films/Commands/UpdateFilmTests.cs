using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Application.Films.Commands.UpdateFilm;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Films.Commands;

public class UpdateFilmTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreNull()
    {
        // Arrange
        var command = new UpdateFilmCommand
        {
            Id = null,
            Title = null,
            Episode = null,
            Director = null,
            ReleaseDate = null,
            ConcurrencyStamp = null
        };

        // Act
        var response = await TestFixture.UpdateFilmAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(6);
    }

    [Fact]
    public async Task Should_ReturnError_When_SomeFieldsAreEmptyOrNotGreaterThanZero()
    {
        // Arrange
        var command = new UpdateFilmCommand
        {
            Id = Guid.Empty,
            Title = string.Empty,
            Episode = -1,
            Director = string.Empty,
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow),
            ConcurrencyStamp = string.Empty
        };

        // Act
        var response = await TestFixture.UpdateFilmAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().BeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().HaveCount(4);
    }

    [Fact]
    public async Task Should_ReturnSuccess_When_AllFieldsAreValid()
    {
        // Arrange
        var film = new Film
        {
            Title = "Title",
            Episode = 1,
            Director = "Director",
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };

        DbContext.Films.Add(film);
        await DbContext.SaveChangesAsync();

        var command = new UpdateFilmCommand
        {
            Id = film.Id,
            Title = "Title2",
            Episode = 2,
            Director = "Director2",
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1)),
            ConcurrencyStamp = film.ConcurrencyStamp
        };

        // Act
        var response = await TestFixture.UpdateFilmAsync(command);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}
