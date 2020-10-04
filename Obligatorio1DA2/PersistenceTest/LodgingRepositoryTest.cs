using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceTest
{
    [TestClass]
    public class LodgingRepositoryTest
    {
        [TestMethod]
        public void Exists()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new LodgingRepository(context);

                Lodging lodging = new Lodging()
                {
                    Name = "lodging1",
                    Direction = "aDirection"
                };

                context.Set<Lodging>().Add(lodging);
                context.SaveChanges();

                bool res = repository.Exists(lodging.Name, lodging.Direction);
                Assert.IsTrue(res);
            }
        }

        [TestMethod]
        public void NotExists()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new LodgingRepository(context);

                Lodging lodging = new Lodging()
                {
                    Name = "lodging1",
                    Direction = "aDirection"
                };

                context.Set<Lodging>().Add(lodging);
                context.SaveChanges();

                bool res = repository.Exists(lodging.Name, "anotherDir");
                Assert.IsFalse(res);
            }
        }
    }
}
