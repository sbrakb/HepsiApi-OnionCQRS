using System.Globalization;
using System.Reflection;
using FluentValidation;
using HepsiApi.Application.Bases;
using HepsiApi.Application.Behaviors;
using HepsiApi.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HepsiApi.Application;

public static class Registration
{
  public static void AddApplication(this IServiceCollection services)
  {
    var assembly = Assembly.GetExecutingAssembly();

    services.AddTransient<ExceptionMiddleware>();

    services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

    services.AddValidatorsFromAssembly(assembly);
    ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehavior<,>));

  }

  private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly,
  Type type)
  {
    var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
    foreach (var item in types)
      services.AddTransient(item);

    return services;
  }
}