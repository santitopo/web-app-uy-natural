using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Models;
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

                Reservation ret = repository.FindByCode(code);

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


        [TestMethod]
        public void GetReportByTPointCheckOrder()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "GetReportByTPointCheckOrder")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new ReservationRepository(context);
                DateTime checkin = DateTime.ParseExact("05102020", "ddMMyyyy", null);
                DateTime checkout = DateTime.ParseExact("08102020", "ddMMyyyy", null);

                TouristicPoint touristicPoint = new TouristicPoint();
                Lodging lodging1 = new Lodging()
                {
                    TouristicPoint = touristicPoint,
                    Name = "lodging1",
                    CreatedDate = new DateTime(2020, 10, 30)
                };
                Lodging lodging2 = new Lodging()
                {
                    TouristicPoint = touristicPoint,
                    Name = "lodging2",
                    CreatedDate = new DateTime(2019, 10, 30)
                };
                Client client = new Client();
                State state = new State();
                Reservation res1 = new Reservation()
                {
                    Lodging = lodging1,
                    CheckIn = new DateTime(2020, 10, 06),
                    CheckOut = new DateTime(2020, 10, 07),
                    Client = client,
                    State = state,
                };
                Reservation res2 = new Reservation()
                {
                    Lodging = lodging1,
                    CheckIn = new DateTime(2020, 10, 06),
                    CheckOut = new DateTime(2020, 10, 16),
                    Client = client,
                    State = state,
                };
                Reservation res3 = new Reservation()
                {
                    Lodging = lodging2,
                    CheckIn = new DateTime(2020, 10, 02),
                    CheckOut = new DateTime(2020, 10, 06),
                    Client = client,
                    State = state,
                };
                Reservation res4 = new Reservation()
                {
                    Lodging = lodging2,
                    CheckIn = new DateTime(2020, 10, 3),
                    CheckOut = new DateTime(2020, 10, 14),
                    Client = client,
                    State = state,
                };

                context.Set<TouristicPoint>().Add(touristicPoint);
                context.Set<Client>().Add(client);
                context.Set<Lodging>().Add(lodging1);
                context.Set<Lodging>().Add(lodging2);
                context.Set<State>().Add(state);
                context.Set<Reservation>().Add(res1);
                context.Set<Reservation>().Add(res2);
                context.Set<Reservation>().Add(res3);
                context.Set<Reservation>().Add(res4);
                context.SaveChanges();

                List<ReservationReportResultModel> ret = repository.GetReportByTPoint(1, checkin, checkout);

                //Checks second ordering criteria (By Lodging creation date)
                Assert.AreEqual(2, ret.Count());
                Assert.AreEqual(ret[0].lodging.Name, "lodging2");
                Assert.AreEqual(ret[0].Reservations, 2);
                Assert.AreEqual(ret[1].lodging.Name, "lodging1");
                Assert.AreEqual(ret[1].Reservations, 2);

                context.Set<TouristicPoint>().Remove(touristicPoint);
                context.Set<Client>().Remove(client);
                context.Set<Lodging>().Remove(lodging1);
                context.Set<Lodging>().Remove(lodging2);
                context.Set<State>().Remove(state);
                context.Set<Reservation>().Remove(res1);
                context.Set<Reservation>().Remove(res2);
                context.Set<Reservation>().Remove(res3);
                context.Set<Reservation>().Remove(res4);
                context.SaveChanges();

            }
        }

        [TestMethod]
        public void GetReportByTPoint()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
           .UseInMemoryDatabase(databaseName: "GetReportByTPoint")
           .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new ReservationRepository(context);
                DateTime checkin = DateTime.ParseExact("05102020", "ddMMyyyy", null);
                DateTime checkout = DateTime.ParseExact("08102020", "ddMMyyyy", null);

                TouristicPoint touristicPoint = new TouristicPoint();
                Lodging lodging1 = new Lodging()
                {
                    TouristicPoint = touristicPoint,
                    Name = "lodging1",
                    CreatedDate = new DateTime(2019, 10, 30)
                };
                Lodging lodging2 = new Lodging()
                {
                    TouristicPoint = touristicPoint,
                    Name = "lodging2",
                    CreatedDate = new DateTime(2020, 10, 30)
                };
                Lodging lodging3 = new Lodging()
                {
                    TouristicPoint = touristicPoint,
                    Name = "lodging3",
                    CreatedDate = new DateTime(2019, 11, 30)
                };
                Client client = new Client();
                State state = new State();
                Reservation res1 = new Reservation()
                {
                    Lodging = lodging1,
                    CheckIn = new DateTime(2020, 10, 03),
                    CheckOut = new DateTime(2020, 10, 08),
                    Client = client,
                    State = state,
                };
                Reservation res2 = new Reservation()
                {
                    Lodging = lodging1,
                    CheckIn = new DateTime(2020, 10, 01),
                    CheckOut = new DateTime(2020, 10, 07),
                    Client = client,
                    State = state,
                };
                Reservation res3 = new Reservation()
                {
                    Lodging = lodging2,
                    CheckIn = new DateTime(2020, 10, 02),
                    CheckOut = new DateTime(2020, 10, 06),
                    Client = client,
                    State = state,
                };
                Reservation res4 = new Reservation()
                {
                    Lodging = lodging3,
                    CheckIn = new DateTime(2020, 10, 09),
                    CheckOut = new DateTime(2020, 10, 14),
                    Client = client,
                    State = state,
                };

                context.Set<TouristicPoint>().Add(touristicPoint);
                context.Set<Client>().Add(client);
                context.Set<Lodging>().Add(lodging1);
                context.Set<Lodging>().Add(lodging2);
                context.Set<Lodging>().Add(lodging3);
                context.Set<State>().Add(state);
                context.Set<Reservation>().Add(res1);
                context.Set<Reservation>().Add(res2);
                context.Set<Reservation>().Add(res3);
                context.Set<Reservation>().Add(res4);
                context.SaveChanges();

                List<ReservationReportResultModel> ret = repository.GetReportByTPoint(1, checkin, checkout);

                //Check that there are only two elements
                Assert.AreEqual(ret.Count(), 2);
                Assert.AreEqual(ret[0].lodging.Name, "lodging1");
                Assert.AreEqual(ret[0].Reservations, 2);
                Assert.AreEqual(ret[1].lodging.Name, "lodging2");
                Assert.AreEqual(ret[1].Reservations, 1);

                context.Set<TouristicPoint>().Remove(touristicPoint);
                context.Set<Client>().Remove(client);
                context.Set<Lodging>().Remove(lodging1);
                context.Set<Lodging>().Remove(lodging2);
                context.Set<Lodging>().Remove(lodging3);
                context.Set<State>().Remove(state);
                context.Set<Reservation>().Remove(res1);
                context.Set<Reservation>().Remove(res2);
                context.Set<Reservation>().Remove(res3);
                context.Set<Reservation>().Remove(res4);
                context.SaveChanges();

            }
        }

        [TestMethod]
        public void GetReportByTPointCheckStates()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
           .UseInMemoryDatabase(databaseName: "GetReportByTPointCheckStates")
           .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new ReservationRepository(context);
                DateTime checkin = DateTime.ParseExact("05102020", "ddMMyyyy", null);
                DateTime checkout = DateTime.ParseExact("08102020", "ddMMyyyy", null);

                TouristicPoint touristicPoint = new TouristicPoint();
                Lodging lodging1 = new Lodging()
                {
                    TouristicPoint = touristicPoint,
                    Name = "lodging1",
                    CreatedDate = new DateTime(2019, 10, 30)
                };
                Lodging lodging2 = new Lodging()
                {
                    TouristicPoint = touristicPoint,
                    Name = "lodging2",
                    CreatedDate = new DateTime(2020, 10, 30)
                };
                Lodging lodging3 = new Lodging()
                {
                    TouristicPoint = touristicPoint,
                    Name = "lodging3",
                    CreatedDate = new DateTime(2019, 11, 30)
                };
                Client client = new Client();
                State state1 = new State()
                {
                    Id = 1,
                    Name = "Expirada"
                };
                State state2 = new State()
                {
                    Id = 2,
                    Name = "Aceptada"
                };
                Reservation res1 = new Reservation()
                {
                    Lodging = lodging1,
                    CheckIn = new DateTime(2020, 10, 03),
                    CheckOut = new DateTime(2020, 10, 08),
                    Client = client,
                    State = state2,
                };
                Reservation res2 = new Reservation()
                {
                    Lodging = lodging1,
                    CheckIn = new DateTime(2020, 10, 01),
                    CheckOut = new DateTime(2020, 10, 07),
                    Client = client,
                    State = state2,
                };
                Reservation res3 = new Reservation()
                {
                    Lodging = lodging2,
                    CheckIn = new DateTime(2020, 10, 02),
                    CheckOut = new DateTime(2020, 10, 06),
                    Client = client,
                    State = state1,
                };
                Reservation res4 = new Reservation()
                {
                    Lodging = lodging3,
                    CheckIn = new DateTime(2020, 10, 09),
                    CheckOut = new DateTime(2020, 10, 14),
                    Client = client,
                    State = state2,
                };

                context.Set<TouristicPoint>().Add(touristicPoint);
                context.Set<Client>().Add(client);
                context.Set<Lodging>().Add(lodging1);
                context.Set<Lodging>().Add(lodging2);
                context.Set<Lodging>().Add(lodging3);
                context.Set<State>().Add(state1);
                context.Set<State>().Add(state2);
                context.Set<Reservation>().Add(res1);
                context.Set<Reservation>().Add(res2);
                context.Set<Reservation>().Add(res3);
                context.Set<Reservation>().Add(res4);
                context.SaveChanges();

                List<ReservationReportResultModel> ret = repository.GetReportByTPoint(1, checkin, checkout);

                //Check that state is not considered
                Assert.AreEqual(ret.Count(), 1);
                Assert.AreEqual(ret[0].lodging.Name, "lodging1");
                Assert.AreEqual(ret[0].Reservations, 2);

                context.Set<TouristicPoint>().Remove(touristicPoint);
                context.Set<Client>().Remove(client);
                context.Set<Lodging>().Remove(lodging1);
                context.Set<Lodging>().Remove(lodging2);
                context.Set<Lodging>().Remove(lodging3);
                context.Set<State>().Remove(state1);
                context.Set<State>().Remove(state2);
                context.Set<Reservation>().Remove(res1);
                context.Set<Reservation>().Remove(res2);
                context.Set<Reservation>().Remove(res3);
                context.Set<Reservation>().Remove(res4);
                context.SaveChanges();

            }
        }


    }
}
