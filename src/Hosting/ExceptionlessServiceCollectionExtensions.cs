using Exceptionless;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Enable.Exceptionless.Extensions.Hosting
{
    public static class ExceptionlessServiceCollectionExtensions
    {
        public static IServiceCollection AddExceptionless(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            if (configuration != null)
            {
                ExceptionlessClient.Default.Configuration.ReadFromConfiguration(configuration);
            }

            return serviceCollection.AddHostedService<ExceptionlessLifetime>();
        }
    }
}
