using Microsoft.EntityFrameworkCore;
using PointCollector.Domain.Entities.Customers;
using PointCollector.Domain.Entities.Workspaces;
using PointCollector.Domain.Entities.Customers.ValueObjects;
using PointCollector.Domain.Entities.Workspaces.ValueObjects;

// Package Manager Console command:
// https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
// dotnet ef migrations add [MIGRATION_NAME] --project .\PointCollector.Infrastructure -s .\PointCollector.API -c PointCollectorContext --verbose
// dotnet ef database update --project .\PointCollector.Infrastructure -s .\PointCollector.API -c PointCollectorContext --verbose
// https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
namespace PointCollector.Infrastructure.Data
{
    public class PointCollectorContext : DbContext
    {
        public PointCollectorContext(DbContextOptions<PointCollectorContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(b => b.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Id).HasConversion(n => n.Id, s => CustomerId.Create());

            modelBuilder.Entity<Workspace>().HasKey(b => b.Id);
            modelBuilder.Entity<Workspace>().Property(c => c.Id).HasConversion(n => n.Id, s => WorkspaceId.Create());
            modelBuilder.Entity<Workspace>().OwnsOne(b => b.Address).ToTable("Address");

        }
    }
}
