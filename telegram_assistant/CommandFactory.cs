using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant
{
    internal class CommandFactory
    {
        public ICommand? CreateCommand(string? commandName, IStorage storage)
        {
            if(commandName == "/store")
            {
                return new StoreCommand(storage);
            }
            else if(commandName == "/get")
            {
                return new GetCommand(storage);
            }
            return null;
            
        }
    }
}
