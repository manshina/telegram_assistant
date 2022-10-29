using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using telegram_assistant.Data;
using telegram_assistant.Models;

namespace telegram_assistant
{
    internal class DbStorage : IStorage
    {
        //private static DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        //private static DbContextOptions<ApplicationDbContext> options = optionsBuilder.UseSqlServer("Server=DESKTOP-2S6G12G\\SQLEXPRESS;Database=LinksDb;Trusted_Connection=True;").Options;

            
        
        
        

        public void AddLink(string link, string category, long id)
        {
            using (ApplicationDbContext ApplicationDbContext = new ApplicationDbContext())
            {
                //var Category = new Category()
                //{
                //    Name = category,
                //    TelegramUserId = Convert.ToInt32(id)

                //};
                //var Link = new Link()
                //{
                //    Name = link,
                //    Category = Category
                //};
                //if (!ApplicationDbContext.Categories.Contains(Category))
                //{
                //    ApplicationDbContext.Categories.Add(Category);

                //}
                //ApplicationDbContext.Links.Add(Link);
                //ApplicationDbContext.SaveChanges();


                var Link = new Link()
                {
                    Name = link,
                    
                };
                try
                {
                    var find = ApplicationDbContext.Categories.Where(x => x.TelegramUserId == id)?.Where(y => y.Name == category).First();
                    Link.Category = find;
                }
                catch
                {
                    var Category = new Category()
                    {
                        Name = category,
                        TelegramUserId = Convert.ToInt32(id)

                    };
                    Link.Category = Category;
                }
                finally
                {
                    ApplicationDbContext.Links.Add(Link);
                    ApplicationDbContext.SaveChanges();
                }


                //var find = ApplicationDbContext.Categories.Where(x => x.Id == id)?.Where(y => y.Name == category).First();
                //if (find == null)
                //{
                //    var Category = new Category()
                //    {
                //        Name = category,
                //        TelegramUserId = Convert.ToInt32(id)

                //    };
                //    Link.Category = Category;
                //}
                //else
                //{
                //    Link.Category = find;
                    
                //}
                //ApplicationDbContext.Links.Add(Link);
                //ApplicationDbContext.SaveChanges();




            }
        }

        public List<string> Get(string category, long id)
        {
            using (ApplicationDbContext ApplicationDbContext = new ApplicationDbContext())
            {
                var result = new List<string>();
                var cat = ApplicationDbContext.Categories.Where(y => y.TelegramUserId == Convert.ToInt32(id)).Where(y => y.Name == category).ToList();
                foreach (var item in cat)
                {
                    var link = ApplicationDbContext.Links.Where(x => x.CategoryId == item.Id).ToList();
                    foreach (var item2 in link)
                    {
                        result.Add(item2.Name);
                    }
                }
                return result;
            }
        }

        public List<string> GetAll(long id)
        {
            using (ApplicationDbContext ApplicationDbContext = new ApplicationDbContext())
            {
                var result = new List<string>();
                var cat = ApplicationDbContext.Categories.Where(y => y.TelegramUserId == Convert.ToInt32(id)).ToList();
                foreach (var item in cat)
                {
                    var link = ApplicationDbContext.Links.Where(x => x.CategoryId == item.Id).ToList();
                    foreach (var item2 in link)
                    {
                        result.Add(item2.Name);
                    }
                }
                return result;
            }
        }
    }
}
