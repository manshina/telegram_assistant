using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant
{
    internal interface IStorage
    {
        public void AddLink(string link, string category);


        public List<string> Get(string category);

        public List<string> GetAll();
    }
}
