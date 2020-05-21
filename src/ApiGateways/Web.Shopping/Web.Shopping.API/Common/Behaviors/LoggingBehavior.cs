using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Web.Shopping.API.Common.Interfaces;

namespace Web.Shopping.API.Common.Behaviors
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly IAppUserService _user;

        public LoggingBehavior(
            ILogger<TRequest> logger,
            IAppUserService user)
        {
            _logger = logger;
            _user = user;
        }

        public async Task Process(
            TRequest request,
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var claimId = _user.ClaimID;
            var identifier = _user.UniqueIdentifier;

            _logger.LogInformation($"Merchant Service Request: {requestName} {claimId} {identifier} {request}");
            await Task.FromResult(0);
        }
    }
}
