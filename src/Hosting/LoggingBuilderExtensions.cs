using System;
using Exceptionless;
using Exceptionless.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ExceptionlessLogLevel = Exceptionless.Logging.LogLevel;

namespace Enable.Exceptionless.Extensions.Hosting
{
    public static class LoggingBuilderExtensions
    {
        public static ILoggingBuilder AddExceptionless(
            this ILoggingBuilder logging,
            IConfiguration configuration)
        {
            return AddExceptionless(logging, configuration, _ => { });
        }

        public static ILoggingBuilder AddExceptionless(
            this ILoggingBuilder logging,
            IConfiguration configuration,
            Action<ExceptionlessConfiguration> configure)
        {
            return logging.AddProvider(new ExceptionlessLoggerProvider(config =>
            {
                if (configuration != null)
                {
                    config.ReadFromConfiguration(configuration);
                    config.SetDefaultMinLogLevel(ExceptionlessLogLevel.FromString(configuration.GetValue("LogLevel", "Error")));
                }

                configure(config);
            }));
        }
    }
}
