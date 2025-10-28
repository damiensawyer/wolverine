using Alba;
using Bogus;
using Bogus.DataSets;
using JasperFx.CommandLine;
using Marten;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Wolverine;
using Xunit.Abstractions;

namespace AppWithMiddleware.Tests;

public class DamoTests
{
    private readonly ITestOutputHelper _output;

    public DamoTests(ITestOutputHelper output)
    {
        // Boo! I blame the AspNetCore team for this one though
        JasperFxEnvironment.AutoStartHost = true;

        this._output = output;
    }


    [Fact]
    public async Task SaveATonneOfDocuments()
    {
        await using var host = await AlbaHost.For<Program>();
        var store = host.Services.GetRequiredService<IDocumentStore>();
        await using var session = store.LightweightSession();
        //svar testUser = FakeUserGenerator.GenerateFakeUser();
        var users = Enumerable.Range(0, 101).Select(x => FakeUserGenerator.GenerateFakeUser()).ToList();
        session.StoreObjects(users);
        await session.SaveChangesAsync();
        
        // load back
        var someBack = await session.Query<User>().Take(10).ToListAsync();
        Assert.NotNull(someBack);
        Assert.True(someBack.Count == 10);
    }
}

