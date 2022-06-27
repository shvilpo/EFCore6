using HelloApp.Models;

namespace HelloApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> _users = new()
                {
                    new User() { Id = 1, Name = "Kost Bravo", Age = 27 },
                    new User() { Id = 2, Name = "Bingo Prix", Age = 29 },
                    new User() { Id = 3, Name = "Annie Larry", Age = 38 },
                    new User() { Id = 4, Name = "Bruce Willie", Age = 58 },
                    new User() { Id = 5, Name = "Whote Orpheus", Age = 32 }
                };
                db.Users.AddRange(_users);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}