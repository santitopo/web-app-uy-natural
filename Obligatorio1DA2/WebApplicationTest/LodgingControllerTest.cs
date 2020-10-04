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
    public class LodgingControllerTest
    {
        [TestMethod]
        public void PostOk()
        {
            var mock1 = new Mock<ISearchLogic>(MockBehavior.Strict);
            var mock2 = new Mock<ILodgingLogic>(MockBehavior.Strict);
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);

            LodgingController controller = new LodgingController(null, null, adminMock.Object);

            LodgingModel lodgingModel = new LodgingModel()
            {
                Name = "lodging1",
            };

            Lodging lodging = new Lodging()
            {
                Name = "lodging1",
            };

            adminMock.Setup(x => x.AddLodging(It.IsAny<Lodging>(), It.IsAny<int>())).Returns(lodging);

            var result = controller.Post(lodgingModel);
            var okResult = result as OkObjectResult;
            var value = okResult.Value as Lodging;

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void InvalidPost()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            LodgingController controller = new LodgingController(null, null, adminMock.Object);

            Lodging nullLodging = null;

            LodgingModel lodgingModel = new LodgingModel()
            {
                Name = "lodging1",
            };

            adminMock.Setup(x => x.AddLodging(It.IsAny<Lodging>(), It.IsAny<int>())).Returns(nullLodging);

            var result = controller.Post(lodgingModel);
            var response = result as ObjectResult;
            Assert.AreEqual(409, response.StatusCode);
            adminMock.VerifyAll();
        }

        [TestMethod]
        public void DeleteOK()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            LodgingController controller = new LodgingController(null, null, adminMock.Object);

            adminMock.Setup(x => x.RemoveLodging(It.IsAny<int>()));

            var result = controller.Delete(1);
            var okResult = result as OkObjectResult;

            adminMock.VerifyAll();
        }

        [TestMethod]
        public void PutOK()
        {
            var adminMock = new Mock<IAdminLogic>(MockBehavior.Strict);
            LodgingController controller = new LodgingController(null, null, adminMock.Object);

            adminMock.Setup(x => x.ModifyLodgingCapacity(It.IsAny<int>(), It.IsAny<bool>()));

            LodgingModel lodgingModel = new LodgingModel()
            {
                Id = 1,
                IsFull = true
            };

            var result = controller.Put(lodgingModel);
            var okResult = result as OkObjectResult;

            adminMock.VerifyAll();
        }
    }
}
