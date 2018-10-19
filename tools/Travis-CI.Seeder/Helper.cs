using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Travis_CI.Api.Data;

namespace Travis_CI.Seeder
{
  public  class Helper
    {
        public ApplicationDbContext GetContextAdnUserManager()
        {

            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();
            var services = new ServiceCollection()
            .AddEntityFrameworkNpgsql();
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];
            Console.WriteLine($"Using Connection string: {connectionString}");
            services.AddDbContext<ApplicationDbContext>(
                opts =>
                {
                    opts.UseNpgsql(connectionString, b => b.MigrationsAssembly("Travis-CI.Api"));
                }
            );         
            var serviceProvider = services.BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder
                  .UseNpgsql(
                      connectionString
                  )
                  .UseInternalServiceProvider(serviceProvider);
            var context = serviceProvider.GetService<ApplicationDbContext>();           
            return context;
        }
    }
}
