using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegram_assistant.Models
{
    internal class Link
    {
        public int id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
