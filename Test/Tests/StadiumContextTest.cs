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
    public class StadiumContextTest : TestManager
    {
        private StadiumContext stadiumContext;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<DBLibraryContext> options = new DbContextOptionsBuilder<DBLibraryContext>()
                .UseInMemoryDatabase(databaseName: "FootballteamsTest")
                .Options;
            DBLibraryContext dbContext = new DBLibraryContext(options);
            stadiumContext = new StadiumContext(dbContext);
        }

        [Test]
        public async Task CreateStadium()
        {
            Stadium stadium = new Stadium
            {
                Name = "Anfield",
                TownName = "Liverpool",
                Capacity = 61000,
                CountryCode = "GB",
                Id = 34
            };

            stadiumContext.CreateAsync(stadium);

            Stadium secondStadium = await stadiumContext.ReadAsync(stadium.Id);
            Assert.That(secondStadium.Name, Is.EqualTo(stadium.Name), "Names are not equal!");
            Assert.That(secondStadium.TownName, Is.EqualTo(stadium.TownName), "Town names are not equal!");
            Assert.That(secondStadium.Capacity, Is.EqualTo(stadium.Capacity), "Capacities are not equal!");
        }

        [Test]
        public async Task ReadStadium()
        {
            Stadium stadium = new Stadium
            {
                Name = "Anfield",
                TownName = "Liverpool",
                Capacity = 61000,
                CountryCode = "GB",
                Id = 5
            };

            stadiumContext.CreateAsync(stadium);

            Stadium readStadium = await stadiumContext.ReadAsync(stadium.Id);
            Assert.That(readStadium.Name, Is.EqualTo(stadium.Name), "Names are not equal!");
        }

        [Test]
        public async Task ReadAllStadiums()
        {
            Stadium stadium1 = new Stadium
            {
                Name = "Old Trafford",
                TownName = "Manchester",
                Capacity = 76000,
                CountryCode = "GB",
                Id = 1
            };
            
            stadiumContext.CreateAsync(stadium1);

            IEnumerable<Stadium> stadiums = await stadiumContext.ReadAllAsync();
            Assert.That(stadiums.Count, Is.EqualTo(2), "Stadiums count is not equal to 2!");
        }

        [Test]
        public async Task UpdateStadium()
        {
            Stadium stadium = new Stadium
            {
                Name = "Anfield",
                TownName = "Liverpool",
                Capacity = 61000,
                CountryCode = "GB",
                Id = 35
            };
            
            stadiumContext.CreateAsync(stadium);

            stadium.Name = "New Stadium";
            stadiumContext.UpdateAsync(stadium);

            Stadium updatedStadium = await stadiumContext.ReadAsync(stadium.Id);
            Assert.That(updatedStadium.Name, Is.EqualTo(stadium.Name), "Names are not equal!");
        }

        [Test]
        public async Task DeleteStadium()
        {
            Stadium stadium = new Stadium
            {
                Name = "Old Trafford",
                TownName = "Manchester",
                Capacity = 76000,
                CountryCode = "GB",
                Id = 1
            };

            stadiumContext.CreateAsync(stadium);
            stadiumContext.DeleteAsync(stadium.Id);

            Assert.Throws<ArgumentException>(() => stadiumContext.ReadAsync(stadium.Id), "Stadium with id does not exist!");
        }
    }
}
