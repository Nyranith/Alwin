using Alwin.CommandLineUtils.Extensions;
using Alwin.Database;
using Alwin.Database.Formatters;
using Alwin.Database.Generation;
using Alwin.Database.Mssql;
using Alwin.Database.Structure;
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
        public ILogger<GenerateSqlCommand> Logger { get; }
        public SQLGenerator SQLGenerator { get; }
        public SQLFormatter SQLFormatter { get; }

        public GenerateSqlCommand(ILogger<GenerateSqlCommand> logger, 
            SQLGenerator sQLGenerator,
            SQLFormatter sQLFormatter
            )
        {
            Logger = logger;
            SQLGenerator = sQLGenerator;
            SQLFormatter = sQLFormatter;
        }

        [Option(CommandOptionType.SingleValue, Description = "Connection string to the databse")]
        public string ConnectionString { get; protected set; }


        [Option(CommandOptionType.SingleValue, Description = "Table")]
        public string Table { get; protected set; }


        [Option(CommandOptionType.NoValue, Description = "Add this if you want to to add join when creating sql")]
        public bool WithJoin { get; protected set; }


        [Option(CommandOptionType.NoValue, Description = "This statements determines if you want to format the sql sentence")]
        public bool DoNotFormatSql { get; protected set; }
       

        private void OnExecute()
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                ConnectionString = Prompt.GetString("Input connection string:");
            }
            
            var mssqlDatabase = new MssqlDatabase(ConnectionString);


            ITable _table = null; 

            if (string.IsNullOrEmpty(Table))
            {
                _table = NavigationPrompter.Navigator(mssqlDatabase.GetTables(), _ => _.Name);
            } else
            {
                _table = mssqlDatabase.GetTables(Table).FirstOrDefault(); 
            }


        }
    }
}
