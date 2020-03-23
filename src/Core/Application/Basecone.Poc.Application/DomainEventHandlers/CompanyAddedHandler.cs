using Basecone.Poc.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.DomainEventHandlers
{
    public class CompanyAddedHandler : INotificationHandler<CompanyAdded>
    {
        private readonly ILogger<CompanyAddedHandler> _logger;

        public CompanyAddedHandler(ILogger<CompanyAddedHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(CompanyAdded notification, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Domain Event [CompanyAdded]:  Office: {notification.Office.OfficeCode}, Company: {notification.Company.CompanyCode}.");
            await Task.Delay(1);
        }
    }
}
