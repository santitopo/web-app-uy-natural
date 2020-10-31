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
    public class TPointRepositoryTest
    {
        [TestMethod]
        public void FindByRegion()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "FindByRegion")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new TPointRepository(context);
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
                    Description = "",
                    Image = "",
                    Name = "",
                    Categories = null,
                    Region = region1
                };
                TouristicPoint tpoint2 = new TouristicPoint()
                {
                    Description = "",
                    Image = "",
                    Name = "",
                    Categories = null,
                    Region = region2
                };
                context.Set<Region>().Add(region1);
                context.Set<Region>().Add(region2);
                context.Set<TouristicPoint>().Add(tpoint1);
                context.Set<TouristicPoint>().Add(tpoint2);
                context.SaveChanges();

                string[] strlst = { };
                IEnumerable<TouristicPoint> tpoints = repository.FindByRegion(4);
                Assert.AreEqual(1, tpoints.Count());

                context.Set<Region>().Remove(region1);
                context.Set<Region>().Remove(region2);
                context.Set<TouristicPoint>().Remove(tpoint1);
                context.Set<TouristicPoint>().Remove(tpoint2);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetAll()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "GetAll")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new TPointRepository(context);

                TouristicPoint tpoint1 = new TouristicPoint()
                {
                    Description = "",
                    Image = "",
                    Name = "",
                    Categories = null,
                    Region = null
                };
                TouristicPoint tpoint2 = new TouristicPoint()
                {
                    Description = "",
                    Image = "",
                    Name = "",
                    Categories = null,
                    Region = null
                };
                context.Set<TouristicPoint>().Add(tpoint1);
                context.Set<TouristicPoint>().Add(tpoint2);
                context.SaveChanges();

                string[] strlst = { };
                IEnumerable<TouristicPoint> tpoints = repository.GetAll(strlst);
                Assert.AreEqual(2, tpoints.Count());

                context.Set<TouristicPoint>().Remove(tpoint1);
                context.Set<TouristicPoint>().Remove(tpoint2);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void FindByRegionCat()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "FindByRegionCat")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new TPointRepository(context);
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
                TouristicPointsCategory TPointCat1 = new TouristicPointsCategory();
                List<TouristicPointsCategory> lst = new List<TouristicPointsCategory>();
                lst.Add(TPointCat1);
                Category cat1 = new Category()
                {
                    Id = 1,
                    Name = "playa",
                    TouristicPoints = lst
                };

                TouristicPoint tpoint1 = new TouristicPoint()
                {
                    Description = "",
                    Image = "",
                    Name = "",
                    Categories = lst,
                    Region = region1
                };
                TouristicPoint tpoint2 = new TouristicPoint()
                {
                    Description = "",
                    Image = "",
                    Name = "",
                    Categories = null,
                    Region = region2
                };

                TPointCat1.Category = cat1;
                TPointCat1.CategoryId = cat1.Id;
                TPointCat1.TouristicPoint= tpoint1;
                TPointCat1.TouristicPointId = tpoint1.Id;


                context.Set<Region>().Add(region1);
                context.Set<Region>().Add(region2);
                context.Set<Category>().Add(cat1);
                context.Set<TouristicPoint>().Add(tpoint1);
                context.Set<TouristicPoint>().Add(tpoint2);
                context.SaveChanges();

                int[] catlst = {1};

                IEnumerable<TouristicPoint> tpoints = repository.FindByRegionCat(4,catlst);
                Assert.AreEqual(1, tpoints.Count());

                context.Set<Region>().Remove(region1);
                context.Set<Region>().Remove(region2);
                context.Set<Category>().Remove(cat1);
                context.Set<TouristicPoint>().Remove(tpoint1);
                context.Set<TouristicPoint>().Remove(tpoint2);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetByName()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new TPointRepository(context);

                TouristicPoint tpoint1 = new TouristicPoint()
                {
                    Description = "",
                    Image = "",
                    Name = "tpoint1",
                    Categories = null,
                    Region = null
                };
                TouristicPoint tpoint2 = new TouristicPoint()
                {
                    Description = "",
                    Image = "",
                    Name = "tpoint2",
                    Categories = null,
                    Region = null
                };
                context.Set<TouristicPoint>().Add(tpoint1);
                context.Set<TouristicPoint>().Add(tpoint2);
                context.SaveChanges();

                TouristicPoint res = repository.GetByName(tpoint1.Name);
                Assert.AreEqual(res, tpoint1);

                context.Set<TouristicPoint>().Remove(tpoint1);
                context.Set<TouristicPoint>().Remove(tpoint2);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetByNameNull()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new TPointRepository(context);

                TouristicPoint tpoint1 = new TouristicPoint()
                {
                    Description = "",
                    Image = "",
                    Name = "tpoint1",
                    Categories = null,
                    Region = null
                };

                context.Set<TouristicPoint>().Add(tpoint1);
                context.SaveChanges();

                TouristicPoint res = repository.GetByName("tpoint2");
                Assert.IsNull(res);

                context.Set<TouristicPoint>().Remove(tpoint1);
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
                var repository = new TPointRepository(context);

                TouristicPoint tpoint1 = new TouristicPoint()
                {
                    Description = "",
                    Image = "",
                    Name = "tpoint1",
                    Categories = null,
                    Region = null
                };

                context.Set<TouristicPoint>().Add(tpoint1);
                context.SaveChanges();

                bool res = repository.Exists(tpoint1.Name);
                Assert.IsTrue(res);

                context.Set<TouristicPoint>().Remove(tpoint1);
                context.SaveChanges();
            }
        }
    }
}
