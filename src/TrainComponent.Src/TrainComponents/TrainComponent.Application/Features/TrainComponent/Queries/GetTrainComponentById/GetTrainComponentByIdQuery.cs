using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainComponent.Application.Features.TrainComponent.Queries.GetTrainComponentById
{
    public class GetTrainComponentByIdQuery : IRequest<TrainComponentVm>
    {
        public Guid Id { get; set; }
    }
}
