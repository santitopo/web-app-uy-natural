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
    public class ReservationRepositoryTest
    {

        [TestMethod]
        public void Exists()
        {

            var options = new DbContextOptionsBuilder<UyNaturalContext>()
           .UseInMemoryDatabase(databaseName: "TestDB")
           .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new ReservationRepository(context);

                Client mockClient = new Client()
                {
                    Mail = "user@test.com",
                    Name = "User",
                    Surname = "Surname"
                };

                Lodging lodging = new Lodging()
                {
                    Id = 4,
                    Capacity = true,
                    Description = "test lodging description",
                    Price = 40,
                    Phone = "+59898259023"
                };

                State defaultState = new State()
                {
                    Name = Constants.DEFAULT_RESERVATION_STATE
                };
                Guid code = Guid.NewGuid();
                Reservation mockReservation = new Reservation()
                {
                    CheckIn = new DateTime(2020, 10, 12),
                    CheckOut = new DateTime(2019, 10, 13),
                    Client = mockClient,
                    Code = code,
                    Lodging = lodging,
                    Price = 50,
                    State = defaultState,
                    StateDescription = Constants.DEFAULT_RESERVATION_STATE,
                };

                context.Set<Client>().Add(mockClient);
                context.Set<Lodging>().Add(lodging);
                context.Set<State>().Add(defaultState);
                context.Set<Reservation>().Add(mockReservation);
                context.SaveChanges();

                bool ret = repository.Exists(code);
                Assert.IsTrue(ret);

                context.Set<Client>().Remove(mockClient);
                context.Set<Lodging>().Remove(lodging);
                context.Set<State>().Remove(defaultState);
                context.Set<Reservation>().Remove(mockReservation);
                context.SaveChanges();

            }
        }

        [TestMethod]
        public void GetDefaultStateCreateIt()
        {

            var options = new DbContextOptionsBuilder<UyNaturalContext>()
           .UseInMemoryDatabase(databaseName: "TestDB")
           .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new ReservationRepository(context);

                State ret = repository.GetDefaultState();

                State check = context.Set<State>().Where(x => x.Name == Constants.DEFAULT_RESERVATION_STATE).FirstOrDefault();
                Assert.AreEqual(ret.Name, check.Name);
                Assert.AreEqual(ret.Id, check.Id);

                context.Set<State>().Remove(check);
                context.SaveChanges();

            }
        }

        [TestMethod]
        public void GetDefaultStateAlreadtExists()
        {

            var options = new DbContextOptionsBuilder<UyNaturalContext>()
           .UseInMemoryDatabase(databaseName: "TestDB")
           .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new ReservationRepository(context);

                State defaultState = new State()
                {
                    Name = Constants.DEFAULT_RESERVATION_STATE
                }; 
                context.Set<State>().Add(defaultState);
                context.SaveChanges();

                State ret = repository.GetDefaultState();

                Assert.AreEqual(ret.Name, defaultState.Name);
                Assert.AreEqual(ret.Id, defaultState.Id);
                Assert.IsTrue(context.Set<State>().ToList().Count() == 1);

                context.Set<State>().Remove(defaultState);
                context.SaveChanges();

            }
        }

        [TestMethod]
        public void FindbyCode()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
          .UseInMemoryDatabase(databaseName: "TestDB")
          .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new ReservationRepository(context);
                Client mockClient = new Client()
                {
                    Mail = "user@test.com",
                    Name = "User",
                    Surname = "Surname"
                };

                Lodging lodging = new Lodging()
                {
                    Id = 4,
                    Capacity = true,
                    Description = "test lodging description",
                    Price = 40,
                    Phone = "+59898259023"
                };

                State defaultState = new State()
                {
                    Name = Constants.DEFAULT_RESERVATION_STATE
                };
                Guid code = Guid.NewGuid();
                Reservation mockReservation = new Reservation()
                {
                    CheckIn = new DateTime(2020, 10, 12),
                    CheckOut = new DateTime(2019, 10, 13),
                    Client = mockClient,
                    Code = code,
                    Lodging = lodging,
                    Price = 50,
                    State = defaultState,
                    StateDescription = Constants.DEFAULT_RESERVATION_STATE,
                };

                context.Set<Client>().Add(mockClient);
                context.Set<Lodging>().Add(lodging);
                context.Set<State>().Add(defaultState);
                context.Set<Reservation>().Add(mockReservation);
                context.SaveChanges();

                Reservation ret = repository.FindbyCode(code);

                Assert.AreEqual(ret.Price, mockReservation.Price);
                Assert.AreEqual(ret.Id, mockReservation.Id);
                Assert.AreEqual(ret.StateDescription, mockReservation.StateDescription);
                Assert.AreEqual(ret.State.Id, mockReservation.State.Id);

                context.Set<Client>().Remove(mockClient);
                context.Set<Lodging>().Remove(lodging);
                context.Set<State>().Remove(defaultState);
                context.Set<Reservation>().Remove(mockReservation);
                context.SaveChanges();

            }
        }
    }
}
