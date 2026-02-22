using BusinessLayer;
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
            DbContextOptions<DBLibraryContext> options = new DbContextOptionsBuilder<DBLibraryContext>()
                .UseInMemoryDatabase(databaseName: "FootballteamsTestDb")
                .Options;
            dbContext = new DBLibraryContext(options);
            countriesContext = new CountryContext(dbContext);
        }

        [Test]
        public async Task CreateCountry()
        {
            Country newCountry = new Country
            {
                CountryName = "Germany",
                CountryCode = "DE",
                ContinentCode = "EU"
            };

            countriesContext.CreateAsync(newCountry);

            Country country = await countriesContext.ReadAsync("DE");
            Assert.That(country, Is.Not.Null);
            Assert.That(country.CountryName, Is.EqualTo("Germany"));
        }

        [Test]
        public async Task ReadCountry()
        {
            Country newCountry = new Country
            {
                CountryName = "Germany",
                CountryCode = "DE",
                ContinentCode = "EU"
            };
            countriesContext.CreateAsync(newCountry);

            Country country = await countriesContext.ReadAsync("DE");

            Assert.That(country.CountryName == "Germany", "Read() does not get Country by CountryCode!");
        }

        [Test]
        public async Task UpdateCountry()
        {
            Country newCountry = new Country
            {
                CountryName = "Germany",
                CountryCode = "DE",
                ContinentCode = "EU"
            };

            newCountry.CountryName = "Deutschland";
            countriesContext.UpdateAsync(newCountry);

            Country updatedCountry = await countriesContext.ReadAsync("DE");
            Assert.That(updatedCountry.CountryName, Is.EqualTo("Deutschland"));
        }

        [Test]
        public async Task DeleteCountry()
        {
            Country newCountry = new Country
            {
                CountryName = "Germany",
                CountryCode = "DE",
                ContinentCode = "EU"
            };

            countriesContext.DeleteAsync("DE");

            ArgumentException ex = Assert.Throws<ArgumentException>(async () => await countriesContext.ReadAsync("DE"));
            Assert.That(ex.Message, Is.EqualTo("Country with CountryCode 'DE' not found!"));
        }
    }
}
