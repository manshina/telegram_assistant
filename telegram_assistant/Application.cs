using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant
{
    
    internal class Application
    {
        
        public void Run()
        {
            ConsoleChat chat = new ConsoleChat();

            IStorage storage = new MemoryStorage();

            CommandHandler commandHandler = new CommandHandler(chat, storage);

            chat.Start();
            

        }
    }
}
