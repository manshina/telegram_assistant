using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using telegram_assistant.Models;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace telegram_assistant.Data
{
    internal class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2S6G12G\SQLEXPRESS;Database=LinksDb;Trusted_Connection=True;");
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Link> Links { get; set; }
    }
}
