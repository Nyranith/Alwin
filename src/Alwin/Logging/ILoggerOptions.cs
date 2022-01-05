using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Alwin.Logging
{
    public interface ILoggerOptions
    {
        bool EnableColors { get; }

        TextWriter Writer { get; }

        Dictionary<LogLevel, ConsoleColor> LogLevels { get; set; }
    }
}