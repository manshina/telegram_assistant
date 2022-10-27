using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant
{
    internal class MemoryStorage: IStorage
    {
        private Dictionary<string, List<string>> LinksStorage = new Dictionary<string, List<string>>
        {
            
        };

        //потом добавить в параметры айди чата
        public void AddLink(string link , string category)
        {
            if (LinksStorage.ContainsKey(category))
            {
                LinksStorage[category].Add(link);
            }
            else
            {
                LinksStorage.Add(category, new List<string> { link });
            }
            
        }


        public List<string> Get(string category)
        {
            return LinksStorage[category];
        }
        public List<string> GetAll()
        {
            List<string> result = new List<string>();

            foreach (var item in LinksStorage)
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
