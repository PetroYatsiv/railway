using TrainComponent.Domain.Entities;

namespace TrainComponent.Application.Contracts.Persistence;

public interface ITrainComponentRepository : IAsyncRepository<TrainComponentNode>
{
}
