using Basecone.Poc.Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.DomainEventHandlers
{
    public class OfficeCreatedHandler : INotificationHandler<OfficeCreated>
    {
        public async Task Handle(OfficeCreated notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Domain Event [OfficeCreated]: Office: {notification.Office.OfficeCode}.");
            await Task.Delay(1);
        }
    }
}
