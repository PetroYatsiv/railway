using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainComponent.Application.Features.TrainComponent.Commands.Create;
using TrainComponent.Application.Features.TrainComponent.Queries;
using TrainComponent.Application.Features.TrainComponent.Queries.FetTrainComponentList;
using TrainComponent.Application.Features.TrainComponent.Queries.GetTrainComponentById;

namespace TrainComponent.Api.Controllers
{
    public class TrainComponentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainComponentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllTrainComponent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TrainComponentVm>>> GetAllTrainComponent()
        {
            var dtos = await _mediator.Send(new GetAllTrainComponentQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetTrainComponentById")]
        public async Task<ActionResult<TrainComponentVm>> GetTrainComponentById(Guid id)
        {
            var getTrainComponentQuery = new GetTrainComponentByIdQuery() { Id = id};
            var dto = await _mediator.Send(getTrainComponentQuery);
            return Ok(dto);
        }

        [HttpPost(Name = "AddTrainComponent")]
        public async Task<ActionResult<TrainComponentVm>> AddTrainComponent([FromBody] CreateComponentCommand createTrainComponentCommand)
        {
            var dto = await _mediator.Send(createTrainComponentCommand);
            return CreatedAtRoute("GetTrainComponentById", new { id = dto }, dto);
        }
    }
}
