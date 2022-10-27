using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant
{
    
    internal class ConsoleChat : IChat
    {
        public event IChat.EventDelegate NewChatMessageRecived;

        public void ChatMessageSent(string answer)
        {
            Console.WriteLine(answer);
        }

        

        public void Start()
        {
            while (true)
            {
                string message = Console.ReadLine();
                if (!(message == null))
                {
                    NewChatMessageRecived(message);
                }
                
                
            }
        }

        public void Stop()
        {
            return;
            
            
        }
    }
}
