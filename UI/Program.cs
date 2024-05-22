using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Core.Interfaces;
using Core.Models;
using Data;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Set up DI container
            var serviceProvider = new ServiceCollection()
                .AddDbContext<kotalkDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddScoped<IUserService, UserRepository>()
                .AddScoped<IMessageService, MessageRepository>()
                .BuildServiceProvider();

            // TEST use service
            var userService = serviceProvider.GetService<IUserService>();
            Console.WriteLine("Hello, World!");

            // App Logic?
        }
    }
}
