using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainComponent.Application.Features.TrainComponent.Commands.Delete
{
    internal class DeleteComponentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
