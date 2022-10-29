using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant.Models
{
    internal class User
    {
        public int Id { get; set; }

        public int TelegramUserId { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        
    }
}
