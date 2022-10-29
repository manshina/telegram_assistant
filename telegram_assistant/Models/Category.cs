using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TelegramUserId { get; set; }

        public List<Link> Links { get; set; }
    }
}
