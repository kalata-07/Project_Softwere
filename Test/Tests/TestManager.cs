using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Tests
{
    [TestFixture]
    public class TestManager
    {
        internal static DBLibraryContext dbContext;
        
        static TestManager()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("TestDb");
            dbContext = new DBLibraryContext(builder.Options);
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
