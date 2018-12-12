using AspNetCoreDevOps.Api.Data;
using AspNetCoreDevOps.Api.Models;
using Faker;
using FizzWare.NBuilder;

namespace AspNetCoreDevOps.Seeder
{
    public class Data
    {
        public static void CreateData(ApplicationDbContext _context)
        {
            var users = Builder<Person>.CreateListOfSize(1000)
                .All()
                .With(c => c.Id = 0)
                .With(c => c.Name = Name.First())
                .With(c => c.Surname = Name.Last())
                .Build();

            _context.People.AddRange(users);
            _context.SaveChanges();
        }
    }
}