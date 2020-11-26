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
    public class ReviewRepositoryTest
    {

        [TestMethod]
        public void ReviewExists()
        {

            var options = new DbContextOptionsBuilder<UyNaturalContext>()
           .UseInMemoryDatabase(databaseName: "ReviewExists")
           .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new ReviewRepository(context);

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

                Review review = new Review()
                {
                    Client = mockClient,
                    Description = "123",
                    Reservation = mockReservation,
                    Score = 3
                };

                context.Set<Client>().Add(mockClient);
                context.Set<Lodging>().Add(lodging);
                context.Set<State>().Add(defaultState);
                context.Set<Reservation>().Add(mockReservation);
                context.Set<Review>().Add(review);
                context.SaveChanges();

                bool ret = repository.ReviewExists(code);
                Assert.IsTrue(ret);

                context.Set<Client>().Remove(mockClient);
                context.Set<Lodging>().Remove(lodging);
                context.Set<State>().Remove(defaultState);
                context.Set<Reservation>().Remove(mockReservation);
                context.Set<Review>().Remove(review);
                context.SaveChanges();

            }
        }

    }
}
