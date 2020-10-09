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

            ReservationModel reservationModel = new ReservationModel()
            {
                Id = 1,
                StateId = 1,
                StateDescription = "This is a test"
            };

            adminMock.Setup(x => x.ModifyReservationState
                (It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
            string token = "123";

            var result = controller.Put(token, reservationModel);
            var okResult = result as OkObjectResult;
            
            adminMock.VerifyAll();
        }
    }
}
