using MediatR;

namespace TrainComponent.Application.Features.TrainComponent.Queries.FetTrainComponentList
{
    public class GetAllTrainComponentQuery : IRequest<List<TrainComponentVm>>
    {
    }
}
