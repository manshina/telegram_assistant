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
            TelegramChat chat = new TelegramChat();

            IStorage storage = new MemoryStorage();
            IStorage dbstorage = new DbStorage();

            CommandHandler commandHandler = new CommandHandler(chat, dbstorage);

            chat.Start();
            
            

        }
    }
}
