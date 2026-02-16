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
        public async Task CreateFootballer()
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

            footballerContext.CreateAsync(footballer);

            Footballer lastFootballer = await footballerContext.ReadAsync(footballer.Id);
            Assert.That(lastFootballer.FirstName, Is.EqualTo(footballer.FirstName), "First names are not equal!");
            Assert.That(lastFootballer.LastName, Is.EqualTo(footballer.LastName), "Last names are not equal!");
        }

        [Test]
        public async Task ReadFootballer()
        {
            Footballer footballer = new Footballer
            {
                FirstName = "Lionel",
                LastName = "Messi",
                Age = 34,
                TeamId = 1,
                CountryCode = "ARG",
                TeamPosition = "Forward"
            };

            footballerContext.CreateAsync(footballer);

            Footballer readFootballer = await footballerContext.ReadAsync(footballer.Id);
            Assert.That(readFootballer.FirstName, Is.EqualTo(footballer.FirstName), "First names are not equal!");
            Assert.That(readFootballer.LastName, Is.EqualTo(footballer.LastName), "Last names are not equal!");
        }

        [Test]
        public async Task ReadAllFootballers()
        {
            Footballer footballer1 = new Footballer
            {
                FirstName = "Neymar",
                LastName = "Jr",
                Age = 29,
                TeamId = 3,
                CountryCode = "BRA",
                TeamPosition = "Forward"
            };

            footballerContext.CreateAsync(footballer1);

            IEnumerable<Footballer> footballers = await footballerContext.ReadAllAsync();
            Assert.That(footballers.Count, Is.EqualTo(2), "Footballers count is not equal to 2!");
        }

        [Test]
        public async Task UpdateFootballerAsync()
        {
            Footballer footballer = new Footballer
            {
                FirstName = "Sergio",
                LastName = "Ramos",
                Age = 35,
                TeamId = 4,
                CountryCode = "ESP",
                TeamPosition = "Defender"
            };

            footballerContext.CreateAsync(footballer);

            footballer.LastName = "Ramos Garcia";
            footballerContext.UpdateAsync(footballer);

            Footballer updatedFootballer = await footballerContext.ReadAsync(footballer.Id);
            Assert.That(updatedFootballer.LastName, Is.EqualTo(footballer.LastName), "Last names are not equal!");
        }

        [Test]
       
        public async Task DeleteFootballer()
        {
            
            Footballer footballer = new Footballer
            {
                FirstName = "Luka",
                LastName = "Modric",
                Age = 35,
                TeamId = 5,
                CountryCode = "CRO",
                TeamPosition = "Midfielder"
            };

            footballerContext.CreateAsync(footballer);
            IEnumerable<Footballer> allFootballers = await footballerContext.ReadAllAsync();
            Footballer createdFootballer = allFootballers.Last();
            int footballerId = createdFootballer.Id;

            footballerContext.DeleteAsync(footballerId);

            KeyNotFoundException ex = Assert.Throws<KeyNotFoundException>(() => footballerContext.ReadAsync(footballerId));
            Assert.That(ex.Message, Is.EqualTo("Footballer not found"));
        }

    }
}
