﻿using Domain;
using Logic;
using LogicInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LogicTest
{
    [TestClass]
    public class ReservationLogicTest
    {
        private Mock<IReservationRepository> reservationsMock;
        private Mock<ILodgingRepository> lodgingsMock;
        private Mock<IPriceCalculator> priceCalculatorMock;
        private Mock<IRepository<Client>> clientsMock;
        private Mock<IAdminRepository> adminsMock;

        [TestInitialize]
        public void Setup()
        {
            reservationsMock = new Mock<IReservationRepository>(MockBehavior.Strict);
            lodgingsMock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            priceCalculatorMock = new Mock<IPriceCalculator>(MockBehavior.Strict);
            clientsMock = new Mock<IRepository<Client>>(MockBehavior.Strict);
            adminsMock = new Mock<IAdminRepository>(MockBehavior.Strict);
        }

        [TestMethod]
        public void BookOkClientExists()
        {

            ReservationLogic logic = new ReservationLogic(reservationsMock.Object, adminsMock.Object,
                lodgingsMock.Object, priceCalculatorMock.Object, clientsMock.Object, null, null,null);

            ReservationModel reservationModel = new ReservationModel()
            {
                AdultsNum = 1,
                BabiesNum = 1,
                ChildsNum = 0,
                Checkin = "12102020",
                Checkout = "13102020",
                LodgingId = 4,
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
            Client mockClient = new Client()
            {
                Mail = "user@test.com",
                Name = "User",
                Surname = "Surname"
            };

            State defaultState = new State()
            {
                Name = Constants.DEFAULT_RESERVATION_STATE
            };

            Reservation mockReservation = new Reservation()
            {
                CheckIn = new DateTime(2020, 10, 12),
                CheckOut = new DateTime(2019, 10, 13),
                Client = mockClient,
                Code = new Guid(),
                Lodging = lodging,
                Price = 50,
                State = defaultState,
                StateDescription = Constants.DEFAULT_RESERVATION_STATE,
            };

            BillModel billMock = new BillModel
            {
                PricePaid = 50,
                Phone = lodging.Phone,
                Description = lodging.Description
            };

            lodgingsMock.Setup(x => x.Get(4)).Returns(lodging);
            priceCalculatorMock.Setup(x => x.CalculatePrice(reservationModel, lodging.Price)).Returns(50);
            adminsMock.Setup(x => x.GetClientbyAttributes(reservationModel.Mail, reservationModel.Name, reservationModel.Surname))
                .Returns(mockClient);
            reservationsMock.Setup(x => x.GetDefaultState()).Returns(defaultState);
            reservationsMock.Setup(x => x.Exists(It.IsAny<Guid>())).Returns(false);
            reservationsMock.Setup(x => x.Create(It.IsAny<Reservation>()));
            reservationsMock.Setup(x => x.Save());


            BillModel ret = logic.BookLodging(reservationModel);

            lodgingsMock.VerifyAll();
            priceCalculatorMock.VerifyAll();
            adminsMock.VerifyAll();
            reservationsMock.VerifyAll();

            Assert.AreEqual(billMock.Phone, ret.Phone);
            Assert.AreEqual(billMock.PricePaid, ret.PricePaid);
            Assert.AreEqual(billMock.Description, ret.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(SystemException), "No se pudo asignar un código único a la reserva")]
        public void BookOkClientNotExists()
        {

            ReservationLogic logic = new ReservationLogic(reservationsMock.Object, adminsMock.Object,
                lodgingsMock.Object, priceCalculatorMock.Object, clientsMock.Object, null, null,null);

            ReservationModel reservationModel = new ReservationModel()
            {
                AdultsNum = 1,
                BabiesNum = 1,
                ChildsNum = 0,
                Checkin = "12102020",
                Checkout = "13102020",
                LodgingId = 4,
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
            Client mockClient = new Client()
            {
                Mail = reservationModel.Mail,
                Name = reservationModel.Name,
                Surname = reservationModel.Surname
            };

            State defaultState = new State()
            {
                Name = Constants.DEFAULT_RESERVATION_STATE
            };

            BillModel billMock = new BillModel
            {
                PricePaid = 50,
                Phone = lodging.Phone,
                Description = lodging.Description
            };

            lodgingsMock.Setup(x => x.Get(4)).Returns(lodging);
            clientsMock.Setup(x => x.Create(mockClient));
            clientsMock.Setup(x => x.Save());
            priceCalculatorMock.Setup(x => x.CalculatePrice(reservationModel, lodging.Price)).Returns(50);
            adminsMock.Setup(x => x.GetClientbyAttributes(reservationModel.Mail, reservationModel.Name, reservationModel.Surname))
                .Returns(mockClient);
            reservationsMock.Setup(x => x.GetDefaultState()).Returns(defaultState);
            reservationsMock.Setup(x => x.Exists(It.IsAny<Guid>())).Returns(true);


            BillModel ret = logic.BookLodging(reservationModel);

            lodgingsMock.VerifyAll();
            priceCalculatorMock.VerifyAll();
            adminsMock.VerifyAll();
            reservationsMock.VerifyAll();

            Assert.AreEqual(billMock.Phone, ret.Phone);
            Assert.AreEqual(billMock.PricePaid, ret.PricePaid);
            Assert.AreEqual(billMock.Description, ret.Description);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "El hospedaje no existe")]
        public void BookFailLodgingNotExists()
        {

            ReservationLogic logic = new ReservationLogic(reservationsMock.Object, adminsMock.Object,
                lodgingsMock.Object, priceCalculatorMock.Object, clientsMock.Object, null, null,null);

            ReservationModel reservationModel = new ReservationModel()
            {
                AdultsNum = 1,
                BabiesNum = 1,
                ChildsNum = 0,
                Checkin = "12102020",
                Checkout = "13102020",
                LodgingId = 4,
                Mail = "user@test.com",
                Name = "User",
                Surname = "Surname"

            };

            Lodging nullLodging = null;
            lodgingsMock.Setup(x => x.Get(4)).Returns(nullLodging);

            var ret = logic.BookLodging(reservationModel);
            lodgingsMock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "El hospedaje no tiene capacidad disponible")]
        public void BookFailLodgingNoCapacity()
        {
            ReservationLogic logic = new ReservationLogic(reservationsMock.Object, adminsMock.Object,
                lodgingsMock.Object, priceCalculatorMock.Object, clientsMock.Object, null, null,null);

            ReservationModel reservationModel = new ReservationModel()
            {
                AdultsNum = 1,
                BabiesNum = 1,
                ChildsNum = 0,
                Checkin = "12102020",
                Checkout = "13102020",
                LodgingId = 4,
                Mail = "user@test.com",
                Name = "User",
                Surname = "Surname"

            };

            Lodging lodging = new Lodging()
            {
                Id = 4,
                Capacity = false,
                Description = "test lodging description",
                Price = 40,
                Phone = "+59898259023"
            };

            lodgingsMock.Setup(x => x.Get(4)).Returns(lodging);

            var ret = logic.BookLodging(reservationModel);
            lodgingsMock.VerifyAll();
        }

        [TestMethod]
        public void GetReservation()
        {

            ReservationLogic logic = new ReservationLogic(reservationsMock.Object, adminsMock.Object,
                lodgingsMock.Object, priceCalculatorMock.Object, clientsMock.Object, null, null,null);
            State defaultState = new State()
            {
                Name = Constants.DEFAULT_RESERVATION_STATE
            };

            Reservation mockReservation = new Reservation()
            {
                CheckIn = new DateTime(2020, 10, 12),
                CheckOut = new DateTime(2019, 10, 13),
                Client = null,
                Code = new Guid(),
                Lodging = null,
                Price = 50,
                State = defaultState,
                StateDescription = Constants.DEFAULT_RESERVATION_STATE,
            };
            Guid guidtest = new Guid("08ACA1E4-436B-4647-A867-801EA91E6431");

            reservationsMock.Setup(x => x.FindByCode(guidtest)).Returns(mockReservation);
            Reservation ret = logic.GetReservationByGuid("08ACA1E4-436B-4647-A867-801EA91E6431");

            reservationsMock.VerifyAll();


        }

        [TestMethod]
        public void GetAllReservations()
        {
            var mock1 = new Mock<IReservationRepository>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<State>>(MockBehavior.Strict);
            ReservationLogic logic = new ReservationLogic(mock1.Object,null,null,null,null, mock2.Object, null,null);

            string[] param = { "State", "Client", "Lodging" };
            mock1.Setup(x => x.GetAll(param)).Returns(It.IsAny<IEnumerable<Reservation>>);

            IEnumerable<Reservation> ret = logic.GetAllReservations();
            mock1.VerifyAll();
        }

        [TestMethod]
        public void GetAllStates()
        {
            var mock1 = new Mock<IReservationRepository>(MockBehavior.Strict);
            var mock2 = new Mock<IRepository<State>>(MockBehavior.Strict);
            ReservationLogic logic = new ReservationLogic(mock1.Object, null, null, null, null, mock2.Object, null,null);

            string[] param = { };
            mock2.Setup(x => x.GetAll(param)).Returns(It.IsAny<IEnumerable<State>>);

            IEnumerable<State> ret = logic.GetAllStates();
            mock1.VerifyAll();
        }

        [TestMethod]
        public void GetReportByTPointOk()
        {
            var mock1 = new Mock<ITPointRepository>(MockBehavior.Strict);
            var mock2 = new Mock<IReservationRepository>(MockBehavior.Strict);
            ReservationLogic logic = new ReservationLogic(mock2.Object, null, null, null, null, null, mock1.Object,null);

            TouristicPoint tpoint = new TouristicPoint()
            {
                Id = 2,
            };

            List<ReservationReportResultModel> res = new List<ReservationReportResultModel>();
            res.Add(new ReservationReportResultModel());

            mock1.Setup(x => x.Get(2)).Returns(tpoint);
            mock2.Setup(x => x.GetReportByTPoint(2, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(res);

            ReservationReportRequestModel request = new ReservationReportRequestModel()
            {
                TPointId = 2,
                FromDate = "02112020",
                ToDate = "03112020",
            };
            IEnumerable<ReservationReportResultModel> ret = logic.GetReportByTPoint(request);
            mock1.VerifyAll();

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "No hay ningun hospedaje con reservas en el periodo buscado")]
        public void GetReportByTPointEmptyLst()
        {
            var mock1 = new Mock<ITPointRepository>(MockBehavior.Strict);
            var mock2 = new Mock<IReservationRepository>(MockBehavior.Strict);
            ReservationLogic logic = new ReservationLogic(mock2.Object, null, null, null, null, null, mock1.Object,null);

            TouristicPoint tpoint = new TouristicPoint()
            {
                Id = 2,
            };

            List<ReservationReportResultModel> res = new List<ReservationReportResultModel>();

            mock1.Setup(x => x.Get(2)).Returns(tpoint);
            mock2.Setup(x => x.GetReportByTPoint(2, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(res);

            ReservationReportRequestModel request = new ReservationReportRequestModel()
            {
                TPointId = 2,
                FromDate = "02112020",
                ToDate = "03112020",
            };
            IEnumerable<ReservationReportResultModel> ret = logic.GetReportByTPoint(request);
            mock1.VerifyAll();

        }

        [TestMethod]
        public void ReviewExistsbyGuid()
        {
            var mock1 = new Mock<IReviewRepository>(MockBehavior.Strict);
            ReservationLogic logic = new ReservationLogic(null, null, null, null, null, null, null, mock1.Object);


            mock1.Setup(x => x.ReviewExists(It.IsAny<Guid>())).Returns(It.IsAny<bool>());
           bool ret = logic.ReviewExistsbyGuid("1A56ACBB-2A98-4AA0-A489-1FA4F63206B6");

            mock1.VerifyAll();
        }

        [TestMethod]
        public void ReviewsExistsByLodging()
        {
            var mock1 = new Mock<IReviewRepository>(MockBehavior.Strict);
            ReservationLogic logic = new ReservationLogic(null, null, null, null, null, null, null, mock1.Object);

            Review aReview = new Review()
            {
                Id = 1,
                Reservation = new Reservation(),
            };

            List<Review> reviews = new List<Review>();
            reviews.Add(aReview);
            string[] param = { "Client", "Reservation", "Reservation.Lodging" };
            mock1.Setup(x => x.GetAll(param)).Returns(reviews);

            IEnumerable<Review> ret = logic.ReviewsByLodging(5);

            mock1.VerifyAll();
        }
    }
}