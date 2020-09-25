using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PersistenceTest
{
    [TestClass]
    public class RegionRepositoryTest
    {
        [TestMethod]
        public void GetRegions()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new Repository<Region>(context);
                Region region1 = new Region()
                {
                     Name = "Este",
                };
                Region region2 = new Region()
                {
                    Name = "Oeste",
                };
                context.Set<Region>().Add(region1);
                context.Set<Region>().Add(region2);
                context.SaveChanges();

                IEnumerable<Region> regions = repository.GetAll();
                Assert.AreEqual(2, regions.Count());
            }
        }
    }
}
