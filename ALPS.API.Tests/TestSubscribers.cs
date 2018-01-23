using ALPS.API.Controllers;
using ALPS.API.Entities;
using ALPS.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ALPS.API.Tests
{
    [TestClass]
    public class TestSubscribers
    {
        private SqliteConnection connection = new SqliteConnection("Datasource=:memory:");
        private DbContextOptions<ALPSContext> options;

        [TestMethod]
        [TestCategory("API.Subscriber")]
        [TestProperty("Level","API")]
        public void GetAll_Returns_List()
        {
            // Arrange
            connection.Open();
            LoadSubscribers(connection);
            List<DTO.SubscriberList> result;

            // Act
            using (var context = new ALPSContext(options))
            {
                var service = new SubscribersController(context);
                result = service.GetSubscribers().ToList();
            }

            // Assert
            Assert.AreEqual(2, result.Count());

            // Clean Up
            connection.Close();
        }

        [TestMethod]
        [TestCategory("API.Subscriber")]
        [TestProperty("Level", "API")]
        public void GetOne_Returns_Record()
        {
            // Arrange
            connection.Open();
            LoadSubscribers(connection);
            ActionResult result;

            // Act
            using (var context = new ALPSContext(options))
            {
                var service = new SubscribersController(context);
                result = service.GetSubscriber(1);
            }

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var x = result as OkObjectResult;
            Assert.IsInstanceOfType(x.Value, typeof(DTO.Subscriber));
            var y = x.Value as DTO.Subscriber;
            Assert.AreEqual(1, (y.Id));

            // Clean Up
            connection.Close();
        }


        [TestMethod]
        [TestCategory("API.Subscriber")]
        [TestProperty("Level", "API")]
        public void GetOne_NotFound()
        {
            // Arrange
            connection.Open();
            LoadSubscribers(connection);
            ActionResult result;

            // Act
            using (var context = new ALPSContext(options))
            {
                var service = new SubscribersController(context);
                result = service.GetSubscriber(3);
            }

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

            // Clean Up
            connection.Close();
        }

        internal void LoadSubscribers(SqliteConnection connection)
        {
            try
            {
                options = new DbContextOptionsBuilder<ALPSContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new ALPSContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new ALPSContext(options))
                {
                    context.Subscribers.Add(new Subscriber { Type = "Repo", Name = "AIRI", TenantName = "AIRI", PrimaryContact = "Mark Hunt", Active = true, Created = DateTime.UtcNow });
                    context.Subscribers.Add(new Subscriber { Type = "Repo", Name = "ARS", TenantName = "ARS", PrimaryContact = "Ron Muliolis", Active = true, Created = DateTime.UtcNow });
                    context.SaveChanges();
                }
            }
            finally { }
        }
    }
}
