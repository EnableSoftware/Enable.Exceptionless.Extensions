using System.Threading;
using System.Threading.Tasks;
using Exceptionless;
using Microsoft.Extensions.Hosting;

namespace Enable.Exceptionless.Extensions.Hosting
{
    public class ExceptionlessLifetime : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            ExceptionlessClient.Default.Startup();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            ExceptionlessClient.Default.Shutdown();

            return Task.CompletedTask;
        }
    }
}
