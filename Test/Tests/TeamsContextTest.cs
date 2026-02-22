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
    public class TeamsContextTest : TestManager
    {
        private TeamsContext teamsContext;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<DBLibraryContext> options = new DbContextOptionsBuilder<DBLibraryContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            dbContext = new DBLibraryContext(options);
            teamsContext = new TeamsContext(dbContext);
        }

        [Test]
        public async Task CreateTeam()
        {
            Team newTeam = new Team
            {
                Id = 7,
                Name = "Real Madrid",
                CountryCode = "ES",
                CoachName = "Carlo Ancelotti",
                Colours = "White and gold",
                Founded = 1902,
                TeamStadium = "Santiago Bernabéu"
            };

            teamsContext.CreateAsync(newTeam);

            Team team = await teamsContext.ReadAsync(7);
            Assert.That(team, Is.Not.Null);
            Assert.That(team.Name, Is.EqualTo("Real Madrid"));
        }

        [Test]
        public async Task ReadTeam()
        {
            Team newTeam = new Team
            {
                Id = 7,
                Name = "Real Madrid",
                CountryCode = "ES",
                CoachName = "Carlo Ancelotti",
                Colours = "White and gold",
                Founded = 1902,
                TeamStadium = "Santiago Bernabéu"
            };
            teamsContext.CreateAsync(newTeam);

            Team team = await teamsContext.ReadAsync(7);

            Assert.That(team.Name == "Real Madrid", "Read() does not get Team by Id!");
        }

        [Test]
        public async Task UpdateTeam()
        {
            Team newTeam = new Team
            {
                Id = 7,
                Name = "Real Madrid",
                CountryCode = "ES",
                CoachName = "Carlo Ancelotti",
                Colours = "White and gold",
                Founded = 1902,
                TeamStadium = "Santiago Bernabéu"
            };
            teamsContext.CreateAsync(newTeam);

            newTeam.Name = "Real Madrid CF";
            teamsContext.UpdateAsync(newTeam);

            Team updatedTeam = await teamsContext.ReadAsync(7);
            Assert.That(updatedTeam.Name, Is.EqualTo("Real Madrid CF"));
        }

        [Test]
        public async Task DeleteTeam()
        {
            Team newTeam = new Team
            {
                Id = 7,
                Name = "Real Madrid",
                CountryCode = "ES",
                CoachName = "Carlo Ancelotti",
                Colours = "White and gold",
                Founded = 1902,
                TeamStadium = "Santiago Bernabéu"
            };
            teamsContext.CreateAsync(newTeam);

            teamsContext.DeleteAsync(7);

            ArgumentException ex = Assert.Throws<ArgumentException>(() => teamsContext.ReadAsync(7));
            Assert.That(ex.Message, Is.EqualTo($"Team with id {newTeam.Id} does not exist!"));
        }



    }
}
