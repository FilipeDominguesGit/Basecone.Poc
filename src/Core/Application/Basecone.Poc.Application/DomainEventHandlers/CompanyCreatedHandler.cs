using Basecone.Poc.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.DomainEventHandlers
{
    public class CompanyCreatedHandler : INotificationHandler<CompanyCreated>
    {
        private readonly ILogger<CompanyCreatedHandler> _logger;

        public CompanyCreatedHandler(ILogger<CompanyCreatedHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(CompanyCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Domain Event [CompanyCreated]: Office: {notification.Company.CompanyCode}.");
            await Task.Delay(1);
        }
    }
}
