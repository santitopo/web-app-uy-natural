using Domain;
using Logic;
using LogicInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersistenceInterface;
using System.Collections.Generic;
using System.Linq;
using Models;
using System;

namespace LogicTest
{
    [TestClass]
    public class LodgingLogicTest
    {
        [TestMethod]
        public void SearchLodgings()
        {
            var mock1 = new Mock<ILodgingRepository>(MockBehavior.Strict);
            var mock2 = new Mock<IPriceCalculator>(MockBehavior.Strict);
            LodgingLogic logic = new LodgingLogic(mock1.Object, mock2.Object, null, null);

            List<Lodging> lst = new List<Lodging>();
            TouristicPoint tpoint = new TouristicPoint()
            {
                Id = 2,
            };
            Lodging lod1 = new Lodging()
            {
                Capacity = true,
                Id = 1,
                IsDeleted = false,
                TouristicPoint = tpoint,
                Price = 20.0,
            };
            Lodging lod2 = new Lodging()
            {
                Capacity = false,
                Id = 2,
                IsDeleted = false,
                TouristicPoint = tpoint,
                Price = 30.0,
            };
            lst.Add(lod1);
            lst.Add(lod2);

            LodgingSearchModel search = new LodgingSearchModel()
            {
                TPointId = 2,
            };
            mock1.Setup(x => x.FindByTPoint(search.TPointId)).Returns(lst);
            mock2.Setup(x => x.CalculatePrice(It.IsAny<LodgingSearchModel>(), 20.0)).Returns(40.0);


            IEnumerable<LodgingSearchResultModel> ret = logic.SearchLodgings(search);

            mock1.VerifyAll();
            Assert.AreEqual(ret.Count(), 1);
            Assert.AreEqual(ret.ElementAt(0).TotalPrice,40.0);
        }

        [TestMethod]
        public void AddReview()
        {
            var mock1 = new Mock<IReservationRepository>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<Review>>(MockBehavior.Strict);
            var mock3 = new Mock<ILodgingRepository>(MockBehavior.Strict);  
            LodgingLogic logic = new LodgingLogic(mock3.Object, null, mock1.Object, mock2.Object);

            Guid code = new Guid();
            Client client = new Client()
            {
                Mail = "user@user.com"
            };
            Lodging lodging = new Lodging()
            {
                Name = "lodging"
            };
            Reservation reservation = new Reservation()
            {
                Code = code,
                Client = client,
                Lodging = lodging
            };

            Review newReview = new Review
            {
                Client = client,
                Reservation = reservation,
                Description = "aDescription",
                Score = 5
            };

            List<Review> reviews = new List<Review>();
            reviews.Add(newReview);

            mock1.Setup(x => x.FindByCode(It.IsAny<Guid>())).Returns(reservation);
            mock2.Setup(x => x.Create(It.IsAny<Review>()));
            mock2.Setup(x => x.Save());
            string[] param = { "Lodging", "Client" };
            mock2.Setup(x => x.GetAll(param)).Returns(reviews);
            mock3.Setup(x => x.Update(It.IsAny<Lodging>()));
            mock3.Setup(x => x.Save());

            Review review = logic.AddReview(code, "aDescription", 5);

            Assert.AreEqual(lodging.Score, 5);
            Assert.AreEqual(review, newReview);

            mock1.VerifyAll();
            mock2.VerifyAll();
            mock3.VerifyAll();


        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "El codigo de reserva no existe")]
        public void InvalidCodeAddReview()
        {
            var mock1 = new Mock<IReservationRepository>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<Review>>(MockBehavior.Strict);
            var mock3 = new Mock<ILodgingRepository>(MockBehavior.Strict);
            LodgingLogic logic = new LodgingLogic(mock3.Object, null, mock1.Object, mock2.Object);

            Reservation nullReservation = null;

            mock1.Setup(x => x.FindByCode(It.IsAny<Guid>())).Returns(nullReservation);
            
            Review review = logic.AddReview(new Guid(), "aDescription", 5);

            mock1.VerifyAll();
        }

    }
}
