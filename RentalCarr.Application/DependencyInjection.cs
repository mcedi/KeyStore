using System.Reflection;
using FluentValidation;
using MediatR;
using KeyStore.Application.Common.Behaviours;

namespace KeyStore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(UnhandledExceptionBehaviour<,>));
        

        return services;
    }
}
