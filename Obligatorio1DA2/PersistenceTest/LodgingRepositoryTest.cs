using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;

namespace PersistenceTest
{
    [TestClass]
    public class LodgingRepositoryTest
    {
        [TestMethod]
        public void FindByTPoint()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new LodgingRepository(context);
                Region region1 = new Region()
                {
                    Id = 4,
                    Name = "Este",
                };
                Region region2 = new Region()
                {
                    Id = 3,
                    Name = "Oeste",
                };
                TouristicPoint tpoint1 = new TouristicPoint()
                {
                    Id = 1,
                    Description = "",
                    Image = "",
                    Name = "",
                    Categories = null,
                    Region = region1
                };
                TouristicPoint tpoint2 = new TouristicPoint()
                {
                    Id = 2,
                    Description = "",
                    Image = "",
                    Name = "",
                    Categories = null,
                    Region = region2
                };
                Lodging lod1 = new Lodging()
                {
                    Id = 1,
                    TouristicPoint = tpoint1,
                };
                Lodging lod2 = new Lodging()
                {
                    Id = 2,
                    TouristicPoint = tpoint2,
                };

                context.Set<Region>().Add(region1);
                context.Set<Region>().Add(region2);
                context.Set<TouristicPoint>().Add(tpoint1);
                context.Set<TouristicPoint>().Add(tpoint2);
                context.Set<Lodging>().Add(lod1);
                context.Set<Lodging>().Add(lod2);
                context.SaveChanges();

                IEnumerable<Lodging> tpoints = repository.FindByTPoint(1);
                Assert.AreEqual(1, tpoints.Count());
                Assert.AreEqual(tpoints.ElementAt(0).Id, 1);

                context.Set<Region>().Remove(region1);
                context.Set<Region>().Remove(region2);
                context.Set<TouristicPoint>().Remove(tpoint1);
                context.Set<TouristicPoint>().Remove(tpoint2);
                context.Set<Lodging>().Remove(lod1);
                context.SaveChanges();
            }
        }

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

                context.Set<Lodging>().Remove(lodging);
                context.SaveChanges();
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

                context.Set<Lodging>().Remove(lodging);
                context.SaveChanges();
            }
        }

    }
}
