using System;
using System.Threading.Tasks;
using AtmApi.Exception;
using AtmApi.Implementations;
using AtmApi.Interfaces;
using AtmRepositoryAdapter;
using Domain.Ports.Primary;
using Domain.Ports.Secondary;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class CoreTests
{
    [Fact]
    public async Task UserLoginTest()
    {
        var collection = new ServiceCollection();

        collection
            .AddScoped<IDbRepository>(p => Substitute.For<IDbRepository>())
            .AddScoped<IAtmRepository, AtmRepository>()
            .AddScoped<IAtmState, UnauthorizedAtmState>()
            .AddScoped<IAtmService, AtmService>();

        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        IDbRepository dbRepo = provider.GetService<IDbRepository>() ?? throw new NotImplementedException();
        IAtmService caller = provider.GetService<IAtmService>() ?? throw new NotImplementedException();

        await caller.UserLogin(1010, 1010).ConfigureAwait(false);
        await dbRepo
            .Received(1)
            .VerifyUser(1010, 1010)
            .ConfigureAwait(false);
    }

    [Fact]
    public async Task AdminCreateTest()
    {
        var collection = new ServiceCollection();

        collection
            .AddScoped<IDbRepository>(p => Substitute.For<IDbRepository>())
            .AddScoped<IAtmRepository, AtmRepository>()
            .AddScoped<IAtmState, AdminAtmState>()
            .AddScoped<IAtmService, AtmService>();

        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        IDbRepository dbRepo = provider.GetService<IDbRepository>() ?? throw new NotImplementedException();
        IAtmService caller = provider.GetService<IAtmService>() ?? throw new NotImplementedException();

        try
        {
            await caller
                .CreateAdmin("j", "d", "admin", "admin")
                .ConfigureAwait(false);
        }
        catch (PasswdBodyException e)
        {
            Assert.Equal("Incorrect length of password, must be more than 7 and less than 20", e.Message);
        }

        await dbRepo
            .DidNotReceive()
            .SaveAdmin("j", "d", "admin", "admin")
            .ConfigureAwait(false);

        await caller
            .CreateAdmin("John", "Dow", "root", "Root1234!")
            .ConfigureAwait(false);

        await dbRepo
            .Received(1)
            .SaveAdmin("John", "Dow", "root", "Root1234!")
            .ConfigureAwait(false);
    }

    // public void AdminWithdrawTest()
    // {
    //     var collection = new ServiceCollection();
    //
    //     collection
    //         .AddScoped<IDbRepository>(p => Substitute.For<IDbRepository>())
    //         .AddScoped<IAtmRepository, AtmRepository>()
    //         .AddScoped<IAtmState, AdminAtmState>()
    //         .AddScoped<IAtmService, AtmService>();
    //
    //     ServiceProvider provider = collection.BuildServiceProvider();
    //     using IServiceScope scope = provider.CreateScope();
    //
    //     IDbRepository dbRepo = provider.GetService<IDbRepository>() ?? throw new NotImplementedException();
    //     IAtmService caller = provider.GetService<IAtmService>() ?? throw new NotImplementedException();
    // }
}