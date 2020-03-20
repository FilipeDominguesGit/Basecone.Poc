using Basecone.Poc.Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.DomainEventHandlers
{
    public class CompanyAddedHandler : INotificationHandler<CompanyAdded>
    {
        public async Task Handle(CompanyAdded notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Domain Event [CompanyAdded]:  Office: {notification.Office.OfficeCode}, Company: {notification.Company.CompanyCode}.");
            await Task.Delay(1);
        }
    }
}
