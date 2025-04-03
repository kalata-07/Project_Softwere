using BuisnessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class CountryContextTest : TestManager
    {
        private CountryContext countriesContext;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<FootballteamsContext> options = new DbContextOptionsBuilder<FootballteamsContext>()
                .UseInMemoryDatabase(databaseName: "FootballteamsTestDb")
                .Options;
            dbContext = new FootballteamsContext(options);
            countriesContext = new CountryContext(dbContext);
        }

        [Test]
        public void CreateCountry()
        {
            Country newCountry = new Country
            {
                CountryName = "Germany",
                CountryCode = "DE",
                ContinentCode = "EU"
            };

            countriesContext.Create(newCountry);

            Country country = countriesContext.Read("DE");
            Assert.That(country, Is.Not.Null);
            Assert.That(country.CountryName, Is.EqualTo("Germany"));
        }

        [Test]
        public void ReadCountry()
        {
            Country newCountry = new Country
            {
                CountryName = "Germany",
                CountryCode = "DE",
                ContinentCode = "EU"
            };
            countriesContext.Create(newCountry);

            Country country = countriesContext.Read("DE");

            Assert.That(country.CountryName == "Germany", "Read() does not get Country by CountryCode!");
        }

        [Test]
        public void UpdateCountry()
        {
            Country newCountry = new Country
            {
                CountryName = "Germany",
                CountryCode = "DE",
                ContinentCode = "EU"
            };

            newCountry.CountryName = "Deutschland";
            countriesContext.Update(newCountry);

            Country updatedCountry = countriesContext.Read("DE");
            Assert.That(updatedCountry.CountryName, Is.EqualTo("Deutschland"));
        }

        [Test]
        public void DeleteCountry()
        {
            Country newCountry = new Country
            {
                CountryName = "Germany",
                CountryCode = "DE",
                ContinentCode = "EU"
            };

            countriesContext.Delete("DE");

            ArgumentException ex = Assert.Throws<ArgumentException>(() => countriesContext.Read("DE"));
            Assert.That(ex.Message, Is.EqualTo("Country with CountryCode 'DE' not found!"));
        }
    }
}
