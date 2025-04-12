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
        public void CreateTeam()
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

            teamsContext.Create(newTeam);

            Team team = teamsContext.Read(7);
            Assert.That(team, Is.Not.Null);
            Assert.That(team.Name, Is.EqualTo("Real Madrid"));
        }

        [Test]
        public void ReadTeam()
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
            teamsContext.Create(newTeam);

            Team team = teamsContext.Read(7);

            Assert.That(team.Name == "Real Madrid", "Read() does not get Team by Id!");
        }

        [Test]
        public void UpdateTeam()
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
            teamsContext.Create(newTeam);

            newTeam.Name = "Real Madrid CF";
            teamsContext.Update(newTeam);

            Team updatedTeam = teamsContext.Read(7);
            Assert.That(updatedTeam.Name, Is.EqualTo("Real Madrid CF"));
        }

        [Test]
        public void DeleteTeam()
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
            teamsContext.Create(newTeam);

            teamsContext.Delete(7);

            ArgumentException ex = Assert.Throws<ArgumentException>(() => teamsContext.Read(7));
            Assert.That(ex.Message, Is.EqualTo($"Team with id {newTeam.Id} does not exist!"));
        }



    }
}
