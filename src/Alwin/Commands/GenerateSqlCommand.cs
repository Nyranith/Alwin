using Alwin.CommandLineUtils.Extensions;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alwin.Commands
{
    internal class GenerateSqlCommand : CommandBase
    {

        public GenerateSqlCommand(ILogger<GenerateSqlCommand> logger1)
        {

        }



        [Option(CommandOptionType.SingleValue, Description = "Name of the database, if there is none selected you will get an interactive prompt.")]
        public string Database { get; protected set;  }

        [Option(CommandOptionType.SingleValue, Description = "Table")]
        public string Table { get; protected set; }

        private void OnExecute()
        {

            if(string.IsNullOrEmpty(Database))
            {
                Database = NavigationPrompter.Navigator(new string[] { "John", "Bill", "Janusz", "Grażyna", "1500", ":)" }, "Janusz");
            }


            if (string.IsNullOrEmpty(Table))
            {
                Database = NavigationPrompter.Navigator(new string[] { "John", "Bill", "Janusz", "Grażyna", "1500", ":)" });
            }


        }
    }
}
