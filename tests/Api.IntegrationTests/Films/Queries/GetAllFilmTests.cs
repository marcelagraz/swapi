using FluentAssertions;
using FluentAssertions.Execution;
using SwApi.Domain.Entities;

namespace SwApi.Api.IntegrationTests.Films.Commands;

public class GetAllFilmTests(TestFixture testFixture) : BaseTests(testFixture)
{
    [Fact]
    public async Task Should_ReturnSuccess_When_AllFieldsAreValid()
    {
        // Arrange
        var utcNow = DateTime.UtcNow.ToString("o");

        var film1 = new Film
        {
            Title = "Title1",
            Episode = 1,
            Director = "Director1",
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow),
            Created = utcNow,
            Edited = utcNow
        };

        var film2 = new Film
        {
            Title = "Title2",
            Episode = 2,
            Director = "Director2",
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow),
            Created = utcNow,
            Edited = utcNow
        };

        var film3 = new Film
        {
            Title = "Title3",
            Episode = 3,
            Director = "Director3",
            ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow),
            Created = utcNow,
            Edited = utcNow
        };

        DbContext.AddRange(film1, film2, film3);
        await DbContext.SaveChangesAsync();

        // Act
        var response = await TestFixture.GetAllFilmAsync();

        // Assert
        using var scope = new AssertionScope();

        response.Should().NotBeNull();
        response!.Data.Should().NotBeNull();
        response.Data.Should().HaveCount(3);
        response.ValidationErrors.Should().NotBeNull();
        response.ValidationErrors.Should().BeEmpty();
    }
}
