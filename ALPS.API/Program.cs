using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace ALPS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "ALPS.API";

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
