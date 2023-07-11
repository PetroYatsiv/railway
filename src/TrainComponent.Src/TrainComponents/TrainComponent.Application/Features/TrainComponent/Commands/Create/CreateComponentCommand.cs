﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponent.Domain.Entities;

namespace TrainComponent.Application.Features.TrainComponent.Commands.Create
{
    public sealed class CreateComponentCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string UniqueNumber { get; set; }
        public bool CanAssignQuantity { get; set; }
        public int? Quantity { get; set; }

        public ICollection<TrainComponentNode> ParentTrainComponents { get; set; }
        public ICollection<TrainComponentNode> ChildTrainComponents { get; set; }
    }
}