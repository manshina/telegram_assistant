using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace telegram_assistant
{
    internal class GetCommand : ICommand
    {
        private readonly IStorage _storage;
        private int state = 0;
        public GetCommand(IStorage storage)
        {
            _storage = storage;
        }

        public string Execute()
        {
            state = 1;
            return "Enter category";
        }

        public string ExecuteNext(string message, CommandRepository commandRepository, long id)
        {
            if(state == 1)
            {
                commandRepository.Delete(id);
                return GetEntity(message, id);

            }
            return null;
            
        }
        public string GetEntity(string category, long id)
        {
            string result = "";
            if (category == "all")
            {
                try
                {
                    foreach (var item in _storage.GetAll(id))
                    {
                        result += $"{item} \n";
                    }
                    return result;
                }
                catch
                {
                    return "no categories exist(/store to add)";
                }
                
            }
            try
            {
                foreach (var item in _storage.Get(category, id))
                {
                    result += $"{item} \n";
                }
                return result;
            }
            catch
            {
                return "no such category exist(all - for all categories)";
            }

            
            
        }


        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
