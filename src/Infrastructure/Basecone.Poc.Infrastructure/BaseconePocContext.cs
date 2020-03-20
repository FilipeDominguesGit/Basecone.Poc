﻿using Basecone.Poc.Infrastructure.Mapper;
using Basecone.Poc.Seedwork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecone.Poc.Infrastructure
{
    public class BaseconePocContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _domainEventsPublisher;

        public BaseconePocContext(DbContextOptions options, IMediator domainEventsPublisher) : base(options)
        {
            _domainEventsPublisher = domainEventsPublisher;
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
                await _domainEventsPublisher.Publish(domainEvent);

        }

        public void RollBack()
        {
            ChangeTracker.Entries().ToList().ForEach(async e => await e.ReloadAsync());
        }
    }
}
