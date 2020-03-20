using Basecone.Poc.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.DomainEventHandlers
{
    public class CompanyCreatedHandler : INotificationHandler<CompanyCreated>
    {
        public async Task Handle(CompanyCreated notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Domain Event [CompanyCreated]: Office: {notification.Company.CompanyCode}.");
            await Task.Delay(1);
        }
    }
}
