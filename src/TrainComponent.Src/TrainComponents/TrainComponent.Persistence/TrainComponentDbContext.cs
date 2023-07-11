using Microsoft.EntityFrameworkCore;
using TrainComponent.Domain.Common;
using TrainComponent.Domain.Entities;

namespace TrainComponent.Persistence;

public class TrainComponentDbContext : DbContext
{
    public TrainComponentDbContext(DbContextOptions<TrainComponentDbContext> options) : base(options)
    {
    }

    public DbSet<TrainComponentNode> TrainComponentNodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainComponentDbContext).Assembly);
    
        //seed data, added through migrations
        var trainComponentNodeGuid1 = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
        var trainComponentNodeGuid2 = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
        var trainComponentNodeGuid3 = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");

        modelBuilder.Entity<TrainComponentNode>().HasData(new TrainComponentNode
        {
            Id = trainComponentNodeGuid1,
            Name = "TrainComponentNode 1",
            CanAssignQuantity = true,
            Quantity = 1
        });
        modelBuilder.Entity<TrainComponentNode>().HasData(new TrainComponentNode
        {
            Id = trainComponentNodeGuid2,
            Name = "TrainComponentNode 2",
            CanAssignQuantity = true,
            Quantity = 2
        });

        modelBuilder.Entity<TrainComponentNode>().HasData(new TrainComponentNode
        {
            Id = trainComponentNodeGuid3,
            Name = "TrainComponentNode 3",
            CanAssignQuantity = false,
            Quantity = null
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = "admin";
                    entry.Entity.Created = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = "admin";
                    entry.Entity.LastModified = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
