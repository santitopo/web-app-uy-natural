using Domain;
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
        private Mock<IUserRepository> adminsMock;

        [TestInitialize]
        public void Setup()
        {
            reservationsMock = new Mock<IReservationRepository>(MockBehavior.Strict);
            lodgingsMock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            priceCalculatorMock = new Mock<IPriceCalculator>(MockBehavior.Strict);
            clientsMock = new Mock<IRepository<Client>>(MockBehavior.Strict);
            adminsMock = new Mock<IUserRepository>(MockBehavior.Strict);
        }

        [TestMethod]
        public void BookOkClientExists()
        {

            ReservationLogic logic = new ReservationLogic(reservationsMock.Object, adminsMock.Object,
                lodgingsMock.Object, priceCalculatorMock.Object, clientsMock.Object);

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
                lodgingsMock.Object, priceCalculatorMock.Object, clientsMock.Object);

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
                lodgingsMock.Object, priceCalculatorMock.Object, clientsMock.Object);

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
                lodgingsMock.Object, priceCalculatorMock.Object, clientsMock.Object);

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
                lodgingsMock.Object, priceCalculatorMock.Object, clientsMock.Object);
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

            reservationsMock.Setup(x => x.FindbyCode(guidtest)).Returns(mockReservation);
            Reservation ret = logic.GetReservationByGuid("08ACA1E4-436B-4647-A867-801EA91E6431");

            reservationsMock.VerifyAll();


        }

    }
}
