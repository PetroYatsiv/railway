using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponent.Application.Contracts.Persistence;
using TrainComponent.Domain.Entities;

namespace TrainComponent.Persistence.Repositories;

public class TrainComponentRepository : BaseRepository<TrainComponentNode>, ITrainComponentRepository
{
    public TrainComponentRepository(TrainComponentDbContext dbContext) : base(dbContext)
    {
    }
    //add any custom methods 
}
