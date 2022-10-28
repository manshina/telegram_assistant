using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace telegram_assistant
{
    internal interface IStorage
    {
        public void AddLink(string link, string category, long id);


        public List<string> Get(string category, long id);

        public List<string> GetAll(long id);
    }
}
