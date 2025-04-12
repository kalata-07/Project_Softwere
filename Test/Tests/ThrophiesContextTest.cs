using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class TrophiesContextTest : TestManager
    {
        private TrophiesContext trophiesContext;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<DBLibraryContext> options = new DbContextOptionsBuilder<DBLibraryContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            dbContext = new DBLibraryContext(options);
            trophiesContext = new TrophiesContext(dbContext);
        }

        [Test]
        public void CreateTrophy()
        {
            Trophy newTrophy = new Trophy
            {
                Id = 11,
                Name = "FA Cup",
                CountryCode = "GB",
                ContinentCode = "EU",
                Footballers = 4
            };

            trophiesContext.Create(newTrophy);

            Trophy trophy = trophiesContext.Read(11);
            Assert.That(trophy, Is.Not.Null);
            Assert.That(trophy.Name, Is.EqualTo("FA Cup"));
        }

        [Test]
        public void ReadTrophy()
        {
            Trophy newTrophy = new Trophy
            {
                Id = 11,
                Name = "FA Cup",
                CountryCode = "GB",
                ContinentCode = "EU",
                Footballers = 4
            };
            trophiesContext.Create(newTrophy);

            Trophy trophy = trophiesContext.Read(11);

            Assert.That(trophy.Name == "FA Cup", "Read() does not get Trophy by Id!");
        }

        [Test]
        public void UpdateTrophy()
        {
            Trophy newTrophy = new Trophy
            {
                Id = 11,
                Name = "FA Cup",
                CountryCode = "GB",
                ContinentCode = "EU",
                Footballers = 4
            };
            trophiesContext.Create(newTrophy);

            newTrophy.Name = "FA World Cup";
            trophiesContext.Update(newTrophy);

            Trophy updatedTrophy = trophiesContext.Read(11);
            Assert.That(updatedTrophy.Name, Is.EqualTo("FA World Cup"));
        }

        [Test]
        public void DeleteTrophy()
        {
            Trophy newTrophy = new Trophy
            {
                Id = 11,
                Name = "FA Cup",
                CountryCode = "GB",
                ContinentCode = "EU",
                Footballers = 4
            };
            trophiesContext.Create(newTrophy);

            trophiesContext.Delete(11);

            ArgumentException ex = Assert.Throws<ArgumentException>(() => trophiesContext.Read(11));
            Assert.That(ex.Message, Is.EqualTo($"Trophy with id {newTrophy.Id} does not exist!"));
        }



    }
}
