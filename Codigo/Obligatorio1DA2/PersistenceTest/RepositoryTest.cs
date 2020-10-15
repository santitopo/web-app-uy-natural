using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistenceTest
{
    [TestClass]
    public class RepositoryTest 
    {

        [TestMethod]
        public void CreateAndDeleteEntity()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new Repository<Region>(context);
                Region region = new Region()
                {
                    Name = "region1"
                };

                repository.Create(region);              
                repository.Save();

                string[] param = { };
                CollectionAssert.Contains(repository.GetAll(param).ToList(), region);

                repository.Delete(region);
                repository.Save();
            }
        }

        [TestMethod]
        public void GetEntity()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new Repository<Region>(context);
                Region region = new Region()
                {
                    Id = 1,
                    Name = "region1"
                };

                context.Add(region);
                context.SaveChanges();

                string[] param = { };
                Assert.AreEqual(repository.Get(1), region);

                context.Remove(region);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void UpdateEntity()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new Repository<Region>(context);
                Region region = new Region()
                {
                    Id = 1,
                    Name = "region1"
                };
                context.Add(region);
                context.SaveChanges();

                string name = "otherName";
                region.Name = name;

                repository.Update(region);
                repository.Save();

                string[] param = { };
                Assert.AreEqual(repository.Get(1).Name, name);

                context.Remove(region);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetAllWithInclude()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB2")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new Repository<Reservation>(context);
                
                Lodging lodging = new Lodging()
                {
                    Name = "aLodging"
                };
                Client client = new Client()
                {
                    Name = "aClient"
                };
                State state = new State()
                {
                    Name = "aState"
                };

                Reservation reservation = new Reservation()
                {
                    Id = 1,
                    Lodging = lodging,
                    Client = client,
                    State = state
                };

                context.Add(reservation);
                context.SaveChanges();

                string[] param = {"Lodging","Client","State"};
                List<Reservation> reservations = repository.GetAll(param).ToList();

                Assert.AreEqual(reservations[0].Lodging, lodging);
                Assert.AreEqual(reservations[0].Client, client);
                Assert.AreEqual(reservations[0].State, state);

                context.Remove(reservation);
                context.SaveChanges();
            }
        }

    }
}
