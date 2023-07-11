using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponent.Application.Contracts.Persistence;
using TrainComponent.Domain.Entities;

namespace TrainComponent.Application.Features.TrainComponent.Commands.Create
{
    internal class CreateComponentCommandHandler : IRequestHandler<CreateComponentCommand, Guid>
    {
        private readonly ITrainComponentRepository _trainComponentRepository;
        private readonly IMapper _mapper;
        public CreateComponentCommandHandler(ITrainComponentRepository trainComponentRepository, IMapper mapper)
        {
            _trainComponentRepository = trainComponentRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
        {
            var component = _mapper.Map<TrainComponentNode>(request);

            var validator = new CreateComponentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0) 
            { 
                throw new Exceptions.ValidationException(validationResult);
            }

            component = await _trainComponentRepository.AddAsync(component);

            return component.Id;
        }
    }
}
