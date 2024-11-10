using Microsoft.Extensions.DependencyInjection;
using SwApi.Infrastructure.Persistence;

namespace SwApi.Api.IntegrationTests;

[Collection("Test Collection")]
public abstract class BaseTests(TestFixture testFixture) : IAsyncLifetime
{
    private IServiceScope _scope = null!;

    protected TestFixture TestFixture = testFixture;
    protected SwApiDbContext DbContext = null!;

    public virtual async Task InitializeAsync()
    {
        await TestFixture.ResetStateAsync();

        _scope = TestFixture.ScopeFactory.CreateScope();

        DbContext = _scope.ServiceProvider.GetRequiredService<SwApiDbContext>();
    }

    public async Task DisposeAsync()
    {
        await DbContext.DisposeAsync();
        _scope.Dispose();
    }
}

[CollectionDefinition("Test Collection")]
public class TestCollection : ICollectionFixture<TestFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
