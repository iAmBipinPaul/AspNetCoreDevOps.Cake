using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Travis_CI.Seeder
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new Helper();
            var result = helper.GetContextAdnUserManager();
            Console.WriteLine("Deleting databse");
            result.Database.EnsureDeleted();
            Console.WriteLine("Applying Migrations");
            result.Database.Migrate();
            Console.WriteLine("Making sure databse is created ");
            result.Database.EnsureCreated();
            Console.WriteLine("Going to save the data ");
            Data.CreateData(result);
            Console.WriteLine("Adding Data into database");
            result.SaveChanges();
            Console.WriteLine("Database sucessfully seeded");
            var totalTopic = result.People.ToList();
            Console.WriteLine($"Total People seedes is {totalTopic.Count()}");
            Console.ReadLine();
        }
    }
}
