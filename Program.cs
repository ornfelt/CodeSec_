using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CodeSec.Models;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;

namespace CodeSec
{
    public class Program
    {
    //main method that initializes database and makes sure its populated - the code is commented for deployment (checklist 11)
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            InitializeDataBase(host);

            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Seeded the database.");

            host.Run();

        }

        private static void InitializeDataBase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                  //two databases are used to seperate responsibility between data and login data (checklist: 2 & 5)   
                    SeedData.EnsurePopulated(services); //calls SeedData with context so it can fill data
                    SeedIdentity.EnsurePopulated(services).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured while seeding the database.");
                }
            }
        }

    //logging used via NLog provider (Checklist: 1 & 10)
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureLogging((hostingContext, logging) =>
            {
              logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
              logging.AddConsole();
              logging.AddDebug();
              logging.AddEventSourceLogger();
                  // Enable NLog as one of the Logging Provider
                  logging.AddNLog();
            }).UseStartup<Startup>();
  }
}
