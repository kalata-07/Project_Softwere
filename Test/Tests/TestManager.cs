using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Tests
{
    [TestFixture]
    public class TestManager
    {
        internal static FootballteamsContext dbContext;
        
        static TestManager()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("TestDb");
            dbContext = new FootballteamsContext(builder.Options);

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }


        [Test]
        public void Test()
        {
          Assert.Pass();
        }
    }
}
