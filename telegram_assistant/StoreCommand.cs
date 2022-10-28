using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace telegram_assistant
{
    internal class StoreCommand : ICommand
    {
        private readonly IStorage _storage;
        private string lastCategory = "";
        private int state = 0;
        public StoreCommand(IStorage storage)
        {
            _storage = storage;
        }

        public string Execute()
        {
            state = 1;
            return "Enter catrgory";
        }

        public string ExecuteNext(string message , CommandRepository commandRepository, long id)
        {
            if(state == 1)
            {
                state++;
                return AddedCategory(message);
                
                
            }
            else if(state == 2)
            {
                state = 0;
                commandRepository.Delete(id);
                return AddedLink(message, id);

            }

            return null;
            
        }
        public string AddedCategory(string category)
        {
            lastCategory = category;

            return "Enter link";
        }
        public string AddedLink(string link, long id)
        {

            _storage.AddLink(link, lastCategory , id);
            return "Link Added";
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
