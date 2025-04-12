using BuisnessLayer;
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
    public class StadiumContextTest : TestManager
    {
        private StadiumContext stadiumContext;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<FootballteamsContext> options = new DbContextOptionsBuilder<FootballteamsContext>()
                .UseInMemoryDatabase(databaseName: "FootballteamsTest")
                .Options;
            FootballteamsContext dbContext = new FootballteamsContext(options);
            stadiumContext = new StadiumContext(dbContext);
        }

        [Test]
        public void CreateStadium()
        {
            Stadium stadium = new Stadium
            {
                Name = "Anfield",
                TownName = "Liverpool",
                Capacity = 61000,
                CountryCode = "GB",
                Id = 34
            };

            stadiumContext.Create(stadium);

            Stadium secondStadium = stadiumContext.Read(stadium.Id);
            Assert.That(secondStadium.Name, Is.EqualTo(stadium.Name), "Names are not equal!");
            Assert.That(secondStadium.TownName, Is.EqualTo(stadium.TownName), "Town names are not equal!");
            Assert.That(secondStadium.Capacity, Is.EqualTo(stadium.Capacity), "Capacities are not equal!");
        }

        [Test]
        public void ReadStadium()
        {
            Stadium stadium = new Stadium
            {
                Name = "Anfield",
                TownName = "Liverpool",
                Capacity = 61000,
                CountryCode = "GB",
                Id = 5
            };

            stadiumContext.Create(stadium);

            Stadium readStadium = stadiumContext.Read(stadium.Id);
            Assert.That(readStadium.Name, Is.EqualTo(stadium.Name), "Names are not equal!");
        }

        [Test]
        public void ReadAllStadiums()
        {
            Stadium stadium1 = new Stadium
            {
                Name = "Old Trafford",
                TownName = "Manchester",
                Capacity = 76000,
                CountryCode = "GB",
                Id = 1
            };
            
            stadiumContext.Create(stadium1);

            List<Stadium> stadiums = stadiumContext.ReadAll();
            Assert.That(stadiums.Count, Is.EqualTo(2), "Stadiums count is not equal to 2!");
        }

        [Test]
        public void UpdateStadium()
        {
            Stadium stadium = new Stadium
            {
                Name = "Anfield",
                TownName = "Liverpool",
                Capacity = 61000,
                CountryCode = "GB",
                Id = 35
            };
            
            stadiumContext.Create(stadium);

            stadium.Name = "New Stadium";
            stadiumContext.Update(stadium);

            Stadium updatedStadium = stadiumContext.Read(stadium.Id);
            Assert.That(updatedStadium.Name, Is.EqualTo(stadium.Name), "Names are not equal!");
        }

        [Test]
        public void DeleteStadium()
        {
            Stadium stadium = new Stadium
            {
                Name = "Old Trafford",
                TownName = "Manchester",
                Capacity = 76000,
                CountryCode = "GB",
                Id = 1
            };

            stadiumContext.Create(stadium);
            stadiumContext.Delete(stadium.Id);

            Assert.Throws<ArgumentException>(() => stadiumContext.Read(stadium.Id), "Stadium with id does not exist!");
        }
    }
}
