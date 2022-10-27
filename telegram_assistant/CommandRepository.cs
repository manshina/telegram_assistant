using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant
{
    internal class CommandRepository
    {
        private ICommand lastCommand = null;

        public void Add(ICommand command)
        {
            lastCommand = command;
        }
        public void Delete()
        {
            lastCommand = null;
        }

        public ICommand Get()
        {
            return lastCommand;
        }
        public bool HasPendingCommand()
        {
            if(lastCommand != null)
            {
                return true;
            }
            return false;
        }
    }
}
