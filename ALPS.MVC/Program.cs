using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace ALPS.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MVC Client";

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
