using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreDevOps.Api.Data;

namespace AspNetCoreDevOps.Seeder
{
    public class Helper
    {
        public ApplicationDbContext GetContextAdnUserManager()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var services = new ServiceCollection()
                .AddEntityFrameworkNpgsql();
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];
            Console.WriteLine($"Using Connection string: {connectionString}");
            services.AddDbContext<ApplicationDbContext>(
                opts => { opts.UseNpgsql(connectionString, b => b.MigrationsAssembly("AspNetCoreDevOps.Api")); }
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