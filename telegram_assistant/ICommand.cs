using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace telegram_assistant
{
    internal interface ICommand
    {
        public string Execute();

        public string ExecuteNext(string message, CommandRepository commandRepository, long id);

        public void Undo();
    }
}
