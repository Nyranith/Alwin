using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Alwin.CLI.Logging
{

    public class ParameterConsoleLogger<T> : ParameterConsoleLogger, ILogger<T>
    {
        public ParameterConsoleLogger(ILoggerOptions options) : base(options)
        {
        }
    }


    /// <summary>
    /// Based on : Bicep.Cli.Logging.BicepConsoleLogger
    /// https://docs.microsoft.com/en-us/dotnet/core/extensions/custom-logging-provider
    /// </summary>
    public class ParameterConsoleLogger : ILogger
    {
        protected readonly ILoggerOptions options;

        public ParameterConsoleLogger(ILoggerOptions options)
        {
            this.options = options;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = formatter(state, exception);

            if (this.options.EnableColors)
            {
                this.LogMessageWithColors(logLevel, message);
            }
            else
            {
                this.LogMessage(logLevel, message);
            }
        }

        public bool IsEnabled(LogLevel logLevel) =>
            options.LogLevels.ContainsKey(logLevel);


        protected void LogMessageWithColors(LogLevel logLevel, string message)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
  

            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = options.LogLevels[logLevel];

            this.LogMessage(logLevel, message);

            Console.ForegroundColor = originalColor;
        }

        protected void LogMessage(LogLevel logLevel, string message)
        {
            this.options.Writer.WriteLine(message);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NullDisposable();
        }

        protected class NullDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}
