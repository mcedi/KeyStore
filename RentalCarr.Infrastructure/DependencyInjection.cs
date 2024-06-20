using KeyStore.Infrastructure.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Entities;
using KeyStore.Application.Common.Interfaces;
using KeyStore.Infrastructure.Auth;
using KeyStore.Infrastructure.Configuration;

namespace KeyStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoDbConfiguration = new MongoDbConfiguration();
        configuration.GetSection("MongoDbConfiguration")
            .Bind(mongoDbConfiguration);

        Task.Run(async () =>
        {
            await DB.InitAsync(mongoDbConfiguration.DatabaseName!,
                MongoClientSettings.FromConnectionString(mongoDbConfiguration.ConnectionString));
        })
            .GetAwaiter()
            .GetResult();

        services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
        services.Configure<MongoDbConfiguration>(configuration.GetSection("MongoDbConfiguration"));

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
