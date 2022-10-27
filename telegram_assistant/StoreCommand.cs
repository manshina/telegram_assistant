using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant
{
    internal class StoreCommand : ICommand, IEnumerable
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

        public string ExecuteNext(string message , CommandRepository commandRepository)
        {
            if(state == 1)
            {
                state++;
                return AddedCategory(message);
                
                
            }
            else if(state == 2)
            {
                state = 0;
                commandRepository.Delete();
                return AddedLink(message);

            }

            return null;
            
        }
        public string AddedCategory(string category)
        {
            lastCategory = category;

            return "Enter link";
        }
        public string AddedLink(string link)
        {

            _storage.AddLink(link, lastCategory);
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
