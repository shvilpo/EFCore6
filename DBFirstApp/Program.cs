using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBFirstApp
{
    internal class Program
    {
        protected static void Main()
        {
            var confbuilder = new ConfigurationBuilder();
            confbuilder.SetBasePath(Directory.GetCurrentDirectory());
            confbuilder.AddJsonFile("appsettings.json");
            var config = confbuilder.Build();
            var str = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var options = optionsBuilder.UseSqlite(str).Options;
            using (AppContext db = new AppContext(options)) 
            {
            //var users = db.Users.ToList();
            //Console.WriteLine("Список объектов:");
            //foreach (User u in users)
            //{
            //    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            //}

            
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();

                var users = db.Users.ToList();
                Console.WriteLine("Список пользователей:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
            
        }
    }
}