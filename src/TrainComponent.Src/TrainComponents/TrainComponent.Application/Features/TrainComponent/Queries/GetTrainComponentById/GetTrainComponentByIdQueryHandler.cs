using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponent.Application.Contracts.Persistence;
using TrainComponent.Domain.Entities;

namespace TrainComponent.Application.Features.TrainComponent.Queries.GetTrainComponentById
{
    internal class GetTrainComponentByIdQueryHandler : 
        IRequestHandler<GetTrainComponentByIdQuery, TrainComponentVm>
    {
        private readonly IAsyncRepository<TrainComponentNode> _trainComponentRepository;
        private readonly IMapper _mapper;
        public GetTrainComponentByIdQueryHandler(IAsyncRepository<TrainComponentNode> trainComponentRepository, IMapper mapper)
        {
            _trainComponentRepository = trainComponentRepository;
            _mapper = mapper;
        }
        public async Task<TrainComponentVm> Handle(GetTrainComponentByIdQuery request, CancellationToken cancellationToken)
        {
            var trainComponent = await _trainComponentRepository.GetByIdAsync(request.Id);

            return _mapper.Map<TrainComponentVm>(trainComponent);
        }
    }
}
