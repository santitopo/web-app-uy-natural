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

        [TestMethod]
        public void LogicalDelete()
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

                repository.Delete(lodging);
                Assert.IsTrue(lodging.IsDeleted);

                context.Set<Lodging>().Remove(lodging);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetAll()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB2")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new LodgingRepository(context);

                Lodging lodging1 = new Lodging()
                {
                    Name = "lodging1",
                    Direction = "aDirection1"
                };
                context.Set<Lodging>().Add(lodging1);
                context.SaveChanges();

                string[] param = { };
                List<Lodging> lodgings = repository.GetAll(param).ToList();
                Assert.AreEqual(1, lodgings.Count);

                Lodging lodging2 = new Lodging()
                {
                    Name = "lodging2",
                    Direction = "aDirection2",
                    IsDeleted = true
                };
                context.Set<Lodging>().Add(lodging2);
                context.SaveChanges();

                List<Lodging> newlodgings = repository.GetAll(param).ToList();
                Assert.AreEqual(1, newlodgings.Count);

                context.Set<Lodging>().Remove(lodging1);
                context.Set<Lodging>().Remove(lodging2);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetDeletedLodging()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new LodgingRepository(context);

                Lodging lodging1 = new Lodging()
                {
                    Id = 1,
                    Name = "lodging1",
                    Direction = "aDirection1",
                    IsDeleted = true
                };
                context.Set<Lodging>().Add(lodging1);
                context.SaveChanges();

                string[] param = { };
                Lodging lodging = repository.Get(1);
                Assert.IsNull(lodging);

                context.Set<Lodging>().Remove(lodging1);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetNotDeletedLodging()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new LodgingRepository(context);

                Lodging lodging1 = new Lodging()
                {
                    Id = 1,
                    Name = "lodging1",
                    Direction = "aDirection1"
                };
                context.Set<Lodging>().Add(lodging1);
                context.SaveChanges();

                string[] param = { };
                Lodging lodging = repository.Get(1);
                Assert.IsNotNull(lodging);

                context.Set<Lodging>().Remove(lodging1);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void CreateLogicalDeletedLodging()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new LodgingRepository(context);

                Lodging lodging1 = new Lodging()
                {
                    Id = 1,
                    Name = "lodging1",
                    Direction = "aDirection1",
                    IsDeleted = true
                };
                context.Set<Lodging>().Add(lodging1);
                context.SaveChanges();

                string[] param = { };
                repository.Create(lodging1);
                context.SaveChanges();

                Assert.IsFalse(lodging1.IsDeleted);

                context.Set<Lodging>().Remove(lodging1);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void CreateNewLodging()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new LodgingRepository(context);

                Lodging lodging1 = new Lodging()
                {
                    Id = 1,
                    Name = "lodging1",
                    Direction = "aDirection1"
                };
                repository.Create(lodging1);
                context.SaveChanges();

                string [] param = { };
                CollectionAssert.Contains(repository.GetAll(param).ToList(),lodging1);

                context.Set<Lodging>().Remove(lodging1);
                context.SaveChanges();
            }
        }

    }
}
