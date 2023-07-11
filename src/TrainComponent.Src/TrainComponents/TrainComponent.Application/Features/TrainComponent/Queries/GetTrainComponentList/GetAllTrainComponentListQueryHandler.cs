using AutoMapper;
using MediatR;
using TrainComponent.Application.Contracts.Persistence;
using TrainComponent.Domain.Entities;

namespace TrainComponent.Application.Features.TrainComponent.Queries.FetTrainComponentList
{
    internal class GetAllTrainComponentListQueryHandler : 
        IRequestHandler<GetAllTrainComponentQuery, List<TrainComponentVm>>
    {
        private readonly IAsyncRepository<TrainComponentNode> _trainComponentRepository;
        private readonly IMapper _mapper;

        public GetAllTrainComponentListQueryHandler(IAsyncRepository<TrainComponentNode> asyncRepository, IMapper mapper)
        {
            _trainComponentRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<List<TrainComponentVm>> Handle(GetAllTrainComponentQuery request, CancellationToken cancellationToken)
        {
            var allTrainComponents = await _trainComponentRepository.ListAllAsync();

            return _mapper.Map<List<TrainComponentVm>>(allTrainComponents);
        }
    }
}
