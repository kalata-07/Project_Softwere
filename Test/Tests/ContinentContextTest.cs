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
    public class ContinentContextTest : TestManager
    {
        private ContinentContext continentsContext;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<DBLibraryContext> options = new DbContextOptionsBuilder<DBLibraryContext>()
                .UseInMemoryDatabase(databaseName: "FootballteamsTestDb")
                .Options;
            dbContext = new DBLibraryContext(options);
            continentsContext = new ContinentContext(dbContext);
        }

        [Test]
        public async Task CreateCotinent()
        {
            Continent newContinent = new Continent
            {
                ContinentName = "Europe",
                ContinentCode = "EU"
            };
            
            continentsContext.CreateAsync(newContinent);

            Continent continent = await continentsContext.ReadAsync("EU");
            Assert.That(continent, Is.Not.Null);
            Assert.That(continent.ContinentName, Is.EqualTo("Europe"));
        }

        [Test]
        public async Task ReadContinent()
        {
            Continent newContinent = new Continent
            {
                ContinentName = "Europe",
                ContinentCode = "EU"
            };
           
            continentsContext.CreateAsync(newContinent);

            Continent continent = await continentsContext.ReadAsync("EU");

            Assert.That(continent.ContinentName == "Europe", "Read() does not get Continent by ContinentCode!");
        }

        [Test]
        public async Task UpdateContinent()
        {
            Continent newContinent = new Continent
            {
                ContinentName = "Europe",
                ContinentCode = "EU"
            };

            newContinent.ContinentName = "Europe";
            continentsContext.UpdateAsync(newContinent);

            Continent updatedContinent = await continentsContext.ReadAsync("EU");
            Assert.That(updatedContinent.ContinentName, Is.EqualTo("Europe"));
        }

        [Test]
        public async Task DeleteContinent()
        {
            Continent newContinent = new Continent
            {
                ContinentName = "Europe",
                ContinentCode = "EU"
            };

            continentsContext.DeleteAsync("EU");

            ArgumentException ex = Assert.Throws<ArgumentException>(async () => await continentsContext.ReadAsync("EU"));
            Assert.That(ex.Message, Is.EqualTo("Continent with ContinentCode 'EU' not found!"));
        }
    }
}
