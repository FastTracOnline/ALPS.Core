using ALPS.API.Entities;
using System;
using System.Linq;

namespace ALPS.API
{
    public static class DatabaseInitializer
    {
        public static void Initialize(ALPSContext context)
        {
            context.Database.EnsureCreated();

            // Look for any subscribers.
            if (context.Subscribers.Any())
            {
                return;   // DB has been seeded
            }

            var subscriberList = new Subscriber[]
            {
                new Subscriber{Name="AIRI",PrimaryContact="Mark Hunt",Active=true,Created=DateTime.Parse("2017-11-01")}
            };

            foreach (Subscriber item in subscriberList)
            {
                context.Subscribers.Add(item);
            }
            context.SaveChanges();
        }
    }
}