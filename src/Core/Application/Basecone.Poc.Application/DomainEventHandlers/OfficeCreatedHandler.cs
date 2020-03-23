using Basecone.Poc.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.DomainEventHandlers
{
    public class OfficeCreatedHandler : INotificationHandler<OfficeCreated>
    {
        private readonly ILogger<OfficeCreatedHandler> _logger;

        public OfficeCreatedHandler(ILogger<OfficeCreatedHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(OfficeCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Domain Event [OfficeCreated]: Office: {notification.Office.OfficeCode}.");
            await Task.Delay(1);
        }
    }
}
