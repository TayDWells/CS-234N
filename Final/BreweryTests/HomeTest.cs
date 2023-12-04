using System.Collections.Generic;
using System.Linq;
using System;

using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using BreweryData.Models;

namespace BreweryTests
{
    [TestFixture]
    public class HomeTest
    {
        bitsContext bitsContext;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AppConfig_ShouldBeValid()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<bitsContext>()
                .UseInMemoryDatabase(databaseName: "AppConfig_ShouldBeValid")
                .Options;

            using (var context = new bitsContext(options))
            {
                var appConfig = new AppConfig
                {
                    // Initialize properties for testing
                    BreweryId = 1,
                    DefaultUnits = "SomeUnits",
                    BreweryName = "Test Brewery",
                    
                };

                // Act
                context.AppConfigs.Add(appConfig);
                context.SaveChanges();

                // Assert
                var savedConfig = context.AppConfigs.Find(appConfig.BreweryId);
                Assert.IsNotNull(savedConfig);
                Assert.AreEqual(appConfig.DefaultUnits, savedConfig.DefaultUnits);
                Assert.AreEqual(appConfig.BreweryName, savedConfig.BreweryName);
                
            }
        }

        [Test]
        public void AppUser_ShouldBeValid()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<bitsContext>()
                .UseInMemoryDatabase(databaseName: "AppUser_ShouldBeValid")
                .Options;

            using (var context = new bitsContext(options))
            {
                var appUser = new AppUser
                {
                    // Initialize properties for testing
                    AppUserId = 1,
                    Name = "Test User",
                    
                };

                // Act
                context.AppUsers.Add(appUser);
                context.SaveChanges();

                // Assert
                var savedUser = context.AppUsers.Find(appUser.AppUserId);
                Assert.IsNotNull(savedUser);
                Assert.AreEqual(appUser.Name, savedUser.Name);
                
            }


        }
    }
}