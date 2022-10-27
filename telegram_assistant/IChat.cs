using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant
{
    internal interface IChat
    {
        public delegate void EventDelegate(string message);

        public event EventDelegate NewChatMessageRecived;


        public void ChatMessageSent(string answer);
        
        public void Start();

        public void Stop();
    }
}
