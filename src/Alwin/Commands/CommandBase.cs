using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alwin.Commands
{
    [HelpOption]

    internal class CommandBase
    {
        [Option(CommandOptionType.SingleValue, ShortName = "v", LongName = "verbosity",
              Description = "Sets the verbosity level of the command. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed].")]
        public LogLevel? Verbosity { get; set; }
    }
}
