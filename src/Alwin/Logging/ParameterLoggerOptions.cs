using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Alwin.Logging
{
    public class LoggerLoggerOptions : ILoggerOptions
    {
        public LoggerLoggerOptions(bool enableColors, TextWriter writer)
        {
            this.EnableColors = enableColors;
            this.Writer = writer;
        }

        public LoggerLoggerOptions(bool enableColors, TextWriter writer, Dictionary<LogLevel, ConsoleColor> logLevels) : this(enableColors, writer)
        {
            this.EnableColors = enableColors;
            this.Writer = writer;

            if (logLevels != null)
            {
                this.LogLevels = logLevels;
            }
        }


        public LoggerLoggerOptions(bool enableColors, TextWriter writer, Func<Dictionary<LogLevel, ConsoleColor>, Dictionary<LogLevel, ConsoleColor>> invokeLogLevels) : this(enableColors, writer)
        {
            if (invokeLogLevels != null)
            {
                LogLevels = invokeLogLevels.Invoke(LogLevels); 
            }
        }

        public LoggerLoggerOptions(bool enableColors, TextWriter writer, Func<Dictionary<LogLevel, ConsoleColor>> invokeLogLevels) : this(enableColors, writer)
        {
            if (invokeLogLevels != null)
            {
                LogLevels = invokeLogLevels.Invoke();
            }
        }

        public bool EnableColors { get; }


        public TextWriter Writer { get; }

        public Dictionary<LogLevel, ConsoleColor> LogLevels { get; set; } = new()
        {
            [LogLevel.Information] = ConsoleColor.Green,
        };
    }
}
