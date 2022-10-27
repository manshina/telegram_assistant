using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string ExecuteNext(string message, CommandRepository commandRepository)
        {
            if(state == 1)
            {
                commandRepository.Delete();
                return GetEntity(message);

            }
            return null;
            
        }
        public string GetEntity(string category)
        {
            string result = "";
            if (category == "all")
            {
                foreach (var item in _storage.GetAll())
                {
                    result += $"{item} \n";
                }
                return result;
            }
            try
            {
                foreach (var item in _storage.Get(category))
                {
                    result += $"{item} \n";
                }
                return result;
            }
            catch
            {
                return "no such category exist";
            }

            
            
        }


        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
