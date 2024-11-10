using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Films.Commands;

public class GetFilmTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnSuccess_When_AllFieldsAreValid()
    {
        // Arrange
        var utcNow = DateTime.UtcNow.ToString("o");

        var film = new Film
        {
            Title = "Title",
            Episode = 1,
            Director = "Director",
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow),
            Created = utcNow,
            Edited = utcNow
        };

        DbContext.Add(film);
        await DbContext.SaveChangesAsync();

        // Act
        var response = await TestFixture.GetFilmAsync(film.Id);

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}
