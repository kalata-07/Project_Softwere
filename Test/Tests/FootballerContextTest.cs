using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class FootballerContextTest : TestManager
    {
        private FootballerContext footballerContext;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<DBLibraryContext> options = new DbContextOptionsBuilder<DBLibraryContext>()
                .UseInMemoryDatabase(databaseName: "FootballteamsTest")
                .Options;
            DBLibraryContext dbContext = new DBLibraryContext(options);
            footballerContext = new FootballerContext(dbContext);
        }

        [Test]
        public void CreateFootballer()
        {
            Footballer footballer = new Footballer
            {
                FirstName = "Cristiano",
                LastName = "Ronaldo",
                Age = 36,
                TeamId = 2,
                CountryCode = "POR",
                TeamPosition = "Forward"
            };

            footballerContext.Create(footballer);

            Footballer lastFootballer = footballerContext.Read(footballer.Id);
            Assert.That(lastFootballer.FirstName, Is.EqualTo(footballer.FirstName), "First names are not equal!");
            Assert.That(lastFootballer.LastName, Is.EqualTo(footballer.LastName), "Last names are not equal!");
        }

        [Test]
        public void ReadFootballer()
        {
            Footballer footballer = new Footballer
            {
                FirstName = "Cristiano",
                LastName = "Ronaldo",
                Age = 36,
                TeamId = 2,
                CountryCode = "POR",
                TeamPosition = "Forward"
            };

            footballerContext.Create(footballer);

            Footballer readFootballer = footballerContext.Read(footballer.Id);
            Assert.That(readFootballer.FirstName, Is.EqualTo(footballer.FirstName), "First names are not equal!");
            Assert.That(readFootballer.LastName, Is.EqualTo(footballer.LastName), "Last names are not equal!");
        }

        [Test]
        public void ReadAllFootballers()
        {
            Footballer footballer1 = new Footballer
            {
                FirstName = "Cristiano",
                LastName = "Ronaldo",
                Age = 36,
                TeamId = 2,
                CountryCode = "POR",
                TeamPosition = "Forward"
            };

            footballerContext.Create(footballer1);

            List<Footballer> footballers = footballerContext.ReadAll();
            Assert.That(footballers.Count, Is.EqualTo(2), "Footballers count is not equal to 2!");
        }

        [Test]
        public void UpdateFootballer()
        {
            Footballer footballer = new Footballer
            {
                FirstName = "Cristiano",
                LastName = "Ronaldo",
                Age = 36,
                TeamId = 2,
                CountryCode = "POR",
                TeamPosition = "Forward"
            };

            footballerContext.Create(footballer);

            footballer.LastName = "Ramos Garcia";
            footballerContext.Update(footballer);

            Footballer updatedFootballer = footballerContext.Read(footballer.Id);
            Assert.That(updatedFootballer.LastName, Is.EqualTo(footballer.LastName), "Last names are not equal!");
        }

        [Test]
        public void DeleteFootballer()
        {
            Footballer footballer = new Footballer
            {
                FirstName = "Cristiano",
                LastName = "Ronaldo",
                Age = 36,
                TeamId = 2,
                CountryCode = "POR",
                TeamPosition = "Forward"
            };

            footballerContext.Create(footballer);
            footballerContext.Delete(footballer.Id);

            Assert.Throws<ArgumentException>(() => footballerContext.Read(footballer.Id), "Footballer with id does not exist!");
        }
    }
}
