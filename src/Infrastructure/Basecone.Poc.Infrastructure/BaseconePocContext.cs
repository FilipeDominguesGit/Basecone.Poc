using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Infrastructure.Mapper;
using Basecone.Poc.Seedwork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Basecone.Poc.Infrastructure
{
    public class BaseconePocContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _domainEventsPublisher;

        public DbSet<Office> Offices { get; set; }

        public BaseconePocContext(DbContextOptions options, IMediator domainEventsPublisher) : base(options)
        {
            _domainEventsPublisher = domainEventsPublisher;
        }
        public BaseconePocContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OfficeMapper).Assembly);
        }

        public async Task Commit()
        {
            var domainEntities = ChangeTracker
              .Entries<Entity>()
              .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            await SaveChangesAsync();

            foreach (var domainEvent in domainEvents)
            {
                await _domainEventsPublisher.Publish(domainEvent);
            }
        }

        public void RollBack()
        {
            ChangeTracker.Entries().ToList().ForEach(async e => await e.ReloadAsync());
        }
    }
}
