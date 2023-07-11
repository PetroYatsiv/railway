using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponent.Application.Contracts.Persistence;
using TrainComponent.Persistence.Repositories;

namespace TrainComponent.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TrainComponentDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("TrainComponentConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ITrainComponentRepository, TrainComponentRepository>();

        return services;
    }
}
