using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponent.Domain.Entities;

namespace TrainComponent.Persistence.Configurations
{
    public class TrainComponentConfiguration : IEntityTypeConfiguration<TrainComponentNode>
    {
        public void Configure(EntityTypeBuilder<TrainComponentNode> builder)
        {
            //configuration for TrainComponentNode entity
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
