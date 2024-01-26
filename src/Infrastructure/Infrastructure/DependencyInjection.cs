using Application.Interfaces.Services;
using Application.Interfaces.Strategy;
using Infrastructure.Abstract;
using Infrastructure.Aggregator;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            /* Manuel Injection */
            /* services.AddTransient<ITaskProvider, TaskProvider1>();
             * services.AddTransient<ITaskProvider, TaskProvider2>();
             * services.AddTransient<ITaskProvider, TaskProvider3>();/

            /* Automatic Injection */
            var providerTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(ITaskProvider).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            string[] passiveProvider = { "TaskProvider3" }; 
            foreach (var type in providerTypes)
            {
                if(passiveProvider.Contains(type.Name)) continue;

                services.AddTransient(typeof(ITaskProvider), type);
            }

            services.AddScoped<DeveloperAggregator>();
            services.AddScoped<IStrategy, AssignStrategy>();
            
            
            return services;
        }
    }
}
