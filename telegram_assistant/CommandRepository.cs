using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace telegram_assistant
{
    internal class CommandRepository
    {
        //private ICommand lastCommand = null;

        Dictionary<long, ICommand> chatLastCommand = new Dictionary<long, ICommand>();

        public void Add(ICommand command, long id)
        {
            //lastCommand = command;
            chatLastCommand[id] = command;
            
           
        }
        public void Delete(long id)
        {
            //lastCommand = null;
            chatLastCommand[id] = null;
        }

        public ICommand Get(long id)
        {
            //return lastCommand;
            
            return chatLastCommand[id];
            
        }
        public bool HasPendingCommand(long id)
        {
            //if(lastCommand != null)
            //{
            //    return true;
            //}
            //return false;
            if (chatLastCommand.ContainsKey(id))
            {
                if(chatLastCommand[id] != null)
                {
                    Console.WriteLine("tyt");
                    return true;
                }
                return false;
            }
            chatLastCommand.Add(id, null);
            Console.WriteLine("sdec");
            return false;
            
        }
    }
}
