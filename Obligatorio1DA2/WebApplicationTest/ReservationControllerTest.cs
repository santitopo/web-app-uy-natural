using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Controllers;

namespace WebApplicationTest
{
    [TestClass]
    public class ReservationControllerTest
    {
        [TestMethod]
        public void GetReservationsOk()
        {
            var mock = new Mock<IAdminLogic>(MockBehavior.Strict);
            var reservationsMock = new Mock<IReservationLogic>(MockBehavior.Strict);
            ReservationController controller = new ReservationController(reservationsMock.Object, mock.Object);

            reservationsMock.Setup(x => x.GetAllReservations()).Returns(It.IsAny<IEnumerable<Reservation>>());

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<Reservation>;

            reservationsMock.VerifyAll();
        }

        [TestMethod]
        public void GetStatesOk()
        {
            var mock = new Mock<IAdminLogic>(MockBehavior.Strict);
            var reservationsMock = new Mock<IReservationLogic>(MockBehavior.Strict);
            ReservationController controller = new ReservationController(reservationsMock.Object, mock.Object);

            reservationsMock.Setup(x => x.GetAllStates()).Returns(It.IsAny<IEnumerable<State>>());

            var result = controller.GetStates();
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<Reservation>;

            reservationsMock.VerifyAll();
        }


        [TestMethod]
        public void PutOk()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);

            ReservationController controller = new ReservationController(null, adminMock.Object);



            ReservationUpdateModel update = new ReservationUpdateModel()
            {
                ReservationId = 2,
                StateDescription = "Pago aceptado",
                StateId = 2,
            };

            adminMock.Setup(x => x.ModifyReservationState(update));

            string token = "123";

            var result = controller.Put(token, update);
            var okResult = result as OkObjectResult;

            adminMock.VerifyAll();
        }


        [TestMethod]
        public void PutException()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);

            ReservationController controller = new ReservationController(null, adminMock.Object);



            ReservationUpdateModel update = new ReservationUpdateModel()
            {
                ReservationId = 2,
                StateDescription = "Pago aceptado",
                StateId = 2,
            };

            adminMock.Setup(x => x.ModifyReservationState(update))
                .Throws(new InvalidOperationException("La reserva o el estado no existen"));
            string token = "123";
            var result = controller.Put(token, update);
            adminMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void PostOk()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);

            var reservationMock = new Mock<IReservationLogic>(MockBehavior.Strict);

            ReservationController controller = new ReservationController(reservationMock.Object, adminMock.Object);

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
            BillModel billreturn = new BillModel()
            {
                Description = "test description",
                Phone = "+59898455545",
                PricePaid = 208,
                ReservationCode = new Guid(),
            };

            reservationMock.Setup(x => x.BookLodging(reservationModel)).Returns(billreturn);
            var result = controller.Post(reservationModel);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as BillModel;

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void BadPost()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);

            var reservationMock = new Mock<IReservationLogic>(MockBehavior.Strict);

            ReservationController controller = new ReservationController(reservationMock.Object, adminMock.Object);

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
            BillModel billreturn = new BillModel()
            {
                Description = "test description",
                Phone = "+59898455545",
                PricePaid = 208,
                ReservationCode = new Guid(),
            };

            reservationMock.Setup(x => x.BookLodging(reservationModel)).Throws(new InvalidOperationException("El hospedaje no existe"));
            var result = controller.Post(reservationModel);


            adminMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void BadPostException()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);

            var reservationMock = new Mock<IReservationLogic>(MockBehavior.Strict);

            ReservationController controller = new ReservationController(reservationMock.Object, adminMock.Object);

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
            BillModel billreturn = new BillModel()
            {
                Description = "test description",
                Phone = "+59898455545",
                PricePaid = 208,
                ReservationCode = new Guid(),
            };

            reservationMock.Setup(x => x.BookLodging(reservationModel)).Throws(new SystemException("No se pudo asignar un código único a la reserva"));
            var result = controller.Post(reservationModel);


            adminMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Get()
        {
            var reservationMock = new Mock<IReservationLogic>(MockBehavior.Strict);
            string guidcode = "guid";
            State stateMock = new State()
            {
                Name = "TestState",
            };
            Reservation reservation = new Reservation()
            {
                State = stateMock,
                StateDescription = "testStateDescription",
            };
            ReservationController controller = new ReservationController(reservationMock.Object, null);
            reservationMock.Setup(x => x.GetReservationByGuid(guidcode)).Returns(reservation);

            StateModel statemodel = new StateModel()
            {
                Description = reservation.StateDescription,
                Name = reservation.State.Name,
            };


            var result = controller.Get("guid");
            var okResult = result as OkObjectResult;
            var value = okResult.Value as StateModel;

            reservationMock.VerifyAll();

        }

        [TestMethod]
        public void GetFailNotExists()
        {
            var reservationMock = new Mock<IReservationLogic>(MockBehavior.Strict);
            string guidcode = "guid";
            State stateMock = new State()
            {
                Name = "TestState",
            };
            //Reservation doesn't exist
            Reservation reservation = null;
            ReservationController controller = new ReservationController(reservationMock.Object, null);
            reservationMock.Setup(x => x.GetReservationByGuid(guidcode)).Returns(reservation);



            var result = controller.Get("guid");
            reservationMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));


        }

        [TestMethod]
        public void GetExceptionNotExists()
        {
            var reservationMock = new Mock<IReservationLogic>(MockBehavior.Strict);
            string guidcode = "guid";
            State stateMock = new State()
            {
                Name = "TestState",
            };
            //Reservation doesn't exist
            Reservation reservation = null;
            ReservationController controller = new ReservationController(reservationMock.Object, null);
            reservationMock.Setup(x => x.GetReservationByGuid(guidcode)).Throws(new InvalidOperationException());



            var result = controller.Get("guid");
            reservationMock.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            }
    }
}
