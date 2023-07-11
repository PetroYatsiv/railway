using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TrainComponent.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //AppDomain.CurrentDomain.GetAssemblies()
            //Assembly.GetExecutingAssembly()
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
