using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponent.Application.Contracts.Persistence;
using TrainComponent.Domain.Entities;

namespace TrainComponent.Application.Features.TrainComponent.Commands.Update
{
    internal class UpdateComponentCommandHandler : IRequestHandler<UpdateComponentCommand>
    {
        private readonly ITrainComponentRepository _trainComponentRepository;
        private readonly IMapper _mapper;
        public UpdateComponentCommandHandler(ITrainComponentRepository trainComponentRepository, IMapper mapper)
        {
            _trainComponentRepository = trainComponentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateComponentCommand request, CancellationToken cancellationToken)
        {
            var componentToUpdate = await _trainComponentRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, componentToUpdate, typeof(UpdateComponentCommand),
                typeof(TrainComponentNode));
            await _trainComponentRepository.UpdateAsync(componentToUpdate);

            return Unit.Value;
        }
    }
}
