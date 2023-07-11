using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponent.Application.Contracts.Persistence;

namespace TrainComponent.Application.Features.TrainComponent.Commands.Delete
{
    internal class DeleteComponentCommandHandler : IRequestHandler<DeleteComponentCommand>
    {
        private readonly ITrainComponentRepository _trainComponentRepository;
        private readonly IMapper _mapper;
        public DeleteComponentCommandHandler(ITrainComponentRepository trainComponentRepository, IMapper mapper)
        {
            _trainComponentRepository = trainComponentRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteComponentCommand request, CancellationToken cancellationToken)
        {
            var componentToDelete = await _trainComponentRepository.GetByIdAsync(request.Id);

            await _trainComponentRepository.DeleteAsync(componentToDelete);

            return Unit.Value;
        }
    }
}
