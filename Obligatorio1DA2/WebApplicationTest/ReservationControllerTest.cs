using Domain;
using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
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



            var result = controller.Put(reservationModel);
            var okResult = result as OkObjectResult;
            
            adminMock.VerifyAll();
        }
    }
}
