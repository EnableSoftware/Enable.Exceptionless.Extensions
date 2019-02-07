using Exceptionless;
using Microsoft.Extensions.Configuration;

namespace Enable.Exceptionless.Extensions.Hosting
{
    public static class ExceptionlessConfigurationExtensions
    {
        public static void ReadFromConfiguration(
            this ExceptionlessConfiguration exceptionlessConfiguration,
            IConfiguration configuration)
        {
            exceptionlessConfiguration.ApiKey = configuration["ApiKey"];
            exceptionlessConfiguration.Enabled = configuration.GetValue<bool>("Enabled");
            exceptionlessConfiguration.ServerUrl = configuration["ServerUrl"];
        }
    }
}
