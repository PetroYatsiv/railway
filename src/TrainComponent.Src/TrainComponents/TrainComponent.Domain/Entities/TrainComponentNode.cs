using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponent.Domain.Common;

namespace TrainComponent.Domain.Entities
{
    public class TrainComponentNode : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UniqueNumber { get; set; }
        public bool CanAssignQuantity { get; set; }
        public int? Quantity { get; set; }

        public ICollection<TrainComponentNode> ParentTrainComponents { get; set; }
        public ICollection<TrainComponentNode> ChildTrainComponents { get; set; }
    }
}