using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace telegram_assistant
{
    internal class MemoryStorage: IStorage
    {
        private Dictionary<long, Dictionary<string, List<string>>> LinksStorage = new Dictionary<long, Dictionary<string, List<string>>>
        {
            
        };

        //потом добавить в параметры айди чата
        public void AddLink(string link , string category, long id)
        {
            if (LinksStorage.ContainsKey(id))
            {
                if (LinksStorage[id].ContainsKey(category))
                {
                    LinksStorage[id][category].Add(link);
                }
                else
                {
                    LinksStorage[id].Add(category, new List<string> { link });
                }

            }
            else
            {
                var ved = new Dictionary<string, List<string>>() { };
                ved.Add(category, new List<string> { link });
                LinksStorage.Add(id, ved);
            }
            
        }


        public List<string> Get(string category, long id)
        {
            return LinksStorage[id][category];
        }
        public List<string> GetAll(long id)
        {
            List<string> result = new List<string>();

            foreach (var item in LinksStorage[id])
            {
                foreach (var item2 in item.Value)
                {
                    result.Add(item2);
                }
            }

            return result;
        }


    }
}
