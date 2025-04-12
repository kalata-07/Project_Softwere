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
        public void CreateCotinent()
        {
            Continent newContinent = new Continent
            {
                ContinentName = "Europe",
                ContinentCode = "EU"
            };
            
            continentsContext.Create(newContinent);

            Continent continent = continentsContext.Read("EU");
            Assert.That(continent, Is.Not.Null);
            Assert.That(continent.ContinentName, Is.EqualTo("Europe"));
        }

        [Test]
        public void ReadContinent()
        {
            Continent newContinent = new Continent
            {
                ContinentName = "Europe",
                ContinentCode = "EU"
            };
           
            continentsContext.Create(newContinent);

            Continent continent = continentsContext.Read("EU");

            Assert.That(continent.ContinentName == "Europe", "Read() does not get Continent by ContinentCode!");
        }

        [Test]
        public void UpdateContinent()
        {
            Continent newContinent = new Continent
            {
                ContinentName = "Europe",
                ContinentCode = "EU"
            };

            newContinent.ContinentName = "Europe";
            continentsContext.Update(newContinent);

            Continent updatedContinent = continentsContext.Read("EU");
            Assert.That(updatedContinent.ContinentName, Is.EqualTo("Europe"));
        }

        [Test]
        public void DeleteContinent()
        {
            Continent newContinent = new Continent
            {
                ContinentName = "Europe",
                ContinentCode = "EU"
            };

            continentsContext.Delete("EU");

            ArgumentException ex = Assert.Throws<ArgumentException>(() => continentsContext.Read("EU"));
            Assert.That(ex.Message, Is.EqualTo("Continent with ContinentCode 'EU' not found!"));
        }
    }
}
