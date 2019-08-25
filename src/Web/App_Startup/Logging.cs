using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Academie.PawnShop.Web.App_Startup
{
    internal static class Logging
    {
        private const string SYSLOG_OUTPUT_TEMPLATE = "[{RequestId} {Level}] {Message}";
        
        private const string FILE_OUTPUT_TEMPLATE = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {RequestId} {Level}] {Message}{NewLine}{Exception}";
        private const string FILE_PATH_TEMPLATE = "App_Data/logs/{Date}.log";

        internal static void Configure(
            ILoggingBuilder loggingBuilder,
            IHostingEnvironment hostingEnvironment,
            IConfigurationSection loggingConfig)
        {
            var loggerConfiguration = new LoggerConfiguration();
            
            loggerConfiguration.MinimumLevel.Debug();

            if (!hostingEnvironment.IsDevelopment())
            {
                var syslogConfig = loggingConfig.GetSection("Syslog");
                var application = $"{hostingEnvironment.ApplicationName}-{hostingEnvironment.EnvironmentName}";
                var server = syslogConfig.GetValue<string>("Server");
                var port = syslogConfig.GetValue<int>("Port");

                var sentryConfig = loggingConfig.GetSection("Sentry");

                loggerConfiguration
                    .WriteTo.Syslog(
                        server,
                        port,
                        application,
                        outputTemplate: SYSLOG_OUTPUT_TEMPLATE)
                    .WriteTo.Sentry(sentryConfig.GetValue<string>("Dsn"));
            }

            Log.Logger = loggerConfiguration
                .WriteTo.RollingFile(
                    FILE_PATH_TEMPLATE, 
                    LogEventLevel.Debug,
                    FILE_OUTPUT_TEMPLATE)
                .CreateLogger();

            loggingBuilder.AddSerilog(Log.Logger);
        }
    }
}