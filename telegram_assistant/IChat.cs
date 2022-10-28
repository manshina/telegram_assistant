using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace telegram_assistant
{
    internal interface IChat
    {
        public delegate void EventDelegate(Message chatMessage);

        public event EventDelegate NewChatMessageRecived;


        public void ChatMessageSent(string answer , Message chat);
        
        public void Start();

        public void Stop();
    }
}
